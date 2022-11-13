using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{   
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject continueIcon;
    //To move the dialogue box
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;

    private Animator layoutAnimator;

    [Header("Choices UI")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [Header("Audio")]
    [SerializeField] private AudioClip[] dialogueTypingSoundClips;
    [Range(1,5)]
    [SerializeField] private int frequencyLevel = 2;
    [Range(-3,3)]
    [SerializeField] private float minPitch = 0.5f;
    [Range(-3,3)]
    [SerializeField] private float maxPitch = 3f;
    [Range(0,10)]
    [SerializeField] private float audioVolume = 1;
    [SerializeField] private bool stopAudioSource;
    [SerializeField] private bool makePredictable;

    private AudioSource audioSource;

    private bool canContinueToNextLine = false;

    private Coroutine displayLineCoroutine;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private Camera cam;

    private DialogueVariables dialogueVariables;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";
    private GameObject talkingCharacter;

    private void Awake() 
    {   
        cam = Camera.main;
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);

        audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    public static DialogueManager GetInstance() 
    {
        return instance;
    }

    private void Start() 
    {
        if (dialoguePanel.name == "DialogueBubbleContainer")
        {
            SetDialogueOnTalkingCharacter();
        }
        dialogueIsPlaying = false;
        
        if (dialoguePanel != null)
        {
        dialoguePanel.SetActive(false);
        }

        layoutAnimator = dialogueUI.GetComponent<Animator>();

        // get all of the choices text 
        if( choices != null)
        {
            choicesText = new TextMeshProUGUI[choices.Length];
            int index = 0;
            foreach (GameObject choice in choices) 
            {
                choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
                index++;
            }
        }
    }

    private void Update() 
    {
        if (dialoguePanel.name == "DialogueBubbleContainer")
        {
            SetDialogueOnTalkingCharacter();
        }
        // return right away if dialogue isn't playing
        if (!dialogueIsPlaying) 
        {
            return;
        }

        // handle continuing to the next line in the dialogue when submit is pressed
        // NOTE: The 'currentStory.currentChoiecs.Count == 0' part was to fix a bug after the Youtube video was made
        if (canContinueToNextLine && currentStory.currentChoices.Count == 0 && InputManager.GetInstance().GetInteractPressed())
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON) 
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);
        
        displayNameText.text = "";
        // portraitAnimator.Play("default");
        layoutAnimator.Play("character");

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode() 
    {
        yield return new WaitForSeconds(0.2f);

        dialogueVariables.StopListening(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        displayNameText.text = "";

    }

    private void ContinueStory() 
    {
        if (currentStory.canContinue) 
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            // set text for the current dialogue line
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
           
            audioSource.PlayOneShot(dialogueTypingSoundClips[1], audioVolume);
            HandleTags(currentStory.currentTags);
        }
        else 
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void PlayDialogueSound(int currentDisplayedCharacterCount,char currentCharacter)
    {
        if (currentDisplayedCharacterCount % frequencyLevel == 0 )
        {
            if (stopAudioSource)
            {
                audioSource.Stop();
            }
            AudioClip soundClip = null;

            if (makePredictable)
            {
                int hashCode = currentCharacter.GetHashCode();
                int predictableIndex = hashCode % dialogueTypingSoundClips.Length;
                soundClip = dialogueTypingSoundClips[predictableIndex];
                // pitch
                int minPitchInt = (int) (minPitch * 100);
                int maxPitchInt = (int) (maxPitch * 100);
                int pitchRangeInt = maxPitchInt - minPitchInt;

                if (pitchRangeInt != 0)
                {
                    int predictablePitchInt = (hashCode % pitchRangeInt) + minPitchInt; 
                    float predictablePitch = predictablePitchInt / 100f;
                    audioSource.pitch = predictablePitch;
                }
                else
                {
                    audioSource.pitch = minPitch;
                }
            }
            else
            {
                // int randomIndex = Random.Range(0,dialogueTypingSoundClips.Length);
                // soundClip = dialogueTypingSoundClips[randomIndex];
                // audioSource.pitch = Random.Range(minPitch,maxPitch);
                // audioSource.PlayOneShot(soundClip);  
            }
            audioSource.PlayOneShot(dialogueTypingSoundClips[0],audioVolume);
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        // empty the dialogue text
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;
        continueIcon.SetActive(false);
        HideChoices();

        canContinueToNextLine = false;

        bool isAddingRichTextTag = false;

        // display each letter one at a time
        foreach (char letter in line.ToCharArray())
        {
            // if the submit button has been pressed, skip to end
            if (InputManager.GetInstance().GetInteractPressed())
            {
                dialogueText.maxVisibleCharacters = line.Length;
                break;
            }

            // check for rich text tag and and it without waiting
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                // dialogueText.text += letter;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            else
            {
                // dialogueText.text += letter; 
                PlayDialogueSound(dialogueText.maxVisibleCharacters, dialogueText.text[dialogueText.maxVisibleCharacters]);
                dialogueText.maxVisibleCharacters++;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        continueIcon.SetActive(true);
        
        DisplayChoices();

        canContinueToNextLine = true;
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private void DisplayChoices() 
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // defensive check to make sure our UI can support the number of choices coming in
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " 
                + currentChoices.Count);
        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach(Choice choice in currentChoices) 
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = " > " + choice.text;
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++) 
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice() 
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            // NOTE: The below two lines were added to fix a bug after the Youtube video was made
            InputManager.GetInstance().GetInteractPressed(); // this is specific to my InputManager script
            ContinueStory();
        }
    }

    public void SetDialogueOnTalkingCharacter()
    {
        GameObject character;
        character = GameObject.FindWithTag("Player");
        // Sets the dialogue position
        SetDialoguePosition(character);
    }

    private void SetDialoguePosition(GameObject character)
    {
        if(dialogueUI != null)
        {
        // Retrieve the position where the top part of the sprite is in the world
        float characterSpriteHeight = character.GetComponent<SpriteRenderer>().bounds.size.y;
        
        // Create position with the sprite top location
        Vector3 characterPosition = new Vector3(character.transform.position.x,
                                                characterSpriteHeight,
                                                character.transform.position.z);

        // Set the DialogueBubble position to the sprite top location in Screen Space
        dialogueUI.transform.position = cam.WorldToScreenPoint(characterPosition);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
         string portraitTag = "";
        // Loop trough all tags
        foreach ( string tag in currentTags)
        {
            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2)
            {
               Debug.Log("Parsing tag error" + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            // if (tagKey == LAYOUT_TAG)
            // {
            //     layoutAnimator.Play(tagValue);
            // }
            // // else if ()
            // // {

            // // }

            // if (dialogueUI.activeSelf)
            // {
            //     Debug.Log("this works");
            //     portraitAnimator.Play(portraitTag);
            // }
            
            // layoutAnimator.Play("character");

            switch (tagKey)
            {
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    // if(tagValue == "item")
                    // {
                    //     dialogueUI.SetActive(false); 
                    // }
                    // else if(tagValue == "character")
                    // {
                    //     dialogueUI.SetActive(true); 
                    //     portraitAnimator.Play(portraitTag);
                    // }
                  break;
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    portraitTag = tagValue;
                    break;
                default:
                    Debug.Log(tag);
                    break;
            }

        }
        
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.Log("Ink Variable not found" + name);
        }
        return variableValue;
    }

}