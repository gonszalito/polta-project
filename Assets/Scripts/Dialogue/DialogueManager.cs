using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{   

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    //To move the dialogue box
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;


    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private Camera cam;

    private DialogueVariables dialogueVariables;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
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
    }

    public static DialogueManager GetInstance() 
    {
        return instance;
    }

    private void Start() 
    {
        SetDialogueOnTalkingCharacter();
        dialogueIsPlaying = false;
        
        if (dialoguePanel != null)
        {
        dialoguePanel.SetActive(false);
        }

        // get all of the choices text 

        // if( choices != null)
        // {
        //     choicesText = new TextMeshProUGUI[choices.Length];
        //     int index = 0;
        //     foreach (GameObject choice in choices) 
        //     {
        //         choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
        //         index++;
        //     }
        // }
    }

    private void Update() 
    {
        
        SetDialogueOnTalkingCharacter();
        // return right away if dialogue isn't playing
        if (!dialogueIsPlaying) 
        {
            return;
        }
        

        // handle continuing to the next line in the dialogue when submit is pressed
        // NOTE: The 'currentStory.currentChoiecs.Count == 0' part was to fix a bug after the Youtube video was made
        if (currentStory.currentChoices.Count == 0 && InputManager.GetInstance().GetSubmitPressed())
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
        


        ContinueStory();
    }

    private IEnumerator ExitDialogueMode() 
    {
        yield return new WaitForSeconds(0.2f);

        dialogueVariables.StopListening(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory() 
    {
        if (currentStory.canContinue) 
        {
            // set text for the current dialogue line
            dialogueText.text = currentStory.Continue();
                // display choices, if any, for this dialogue line
            // DisplayChoices()
            HandleTags(currentStory.currentTags);
        }
        else 
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    // private void DisplayChoices() 
    // {
    //     List<Choice> currentChoices = currentStory.currentChoices;

    //     // defensive check to make sure our UI can support the number of choices coming in
    //     if (currentChoices.Count > choices.Length)
    //     {
    //         Debug.LogError("More choices were given than the UI can support. Number of choices given: " 
    //             + currentChoices.Count);
    //     }

    //     int index = 0;
    //     // enable and initialize the choices up to the amount of choices for this line of dialogue
    //     foreach(Choice choice in currentChoices) 
    //     {
    //         choices[index].gameObject.SetActive(true);
    //         choicesText[index].text = choice.text;
    //         index++;
    //     }
    //     // go through the remaining choices the UI supports and make sure they're hidden
    //     for (int i = index; i < choices.Length; i++) 
    //     {
    //         choices[i].gameObject.SetActive(false);
    //     }

    //     StartCoroutine(SelectFirstChoice());
    // }

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
        currentStory.ChooseChoiceIndex(choiceIndex);
        // NOTE: The below two lines were added to fix a bug after the Youtube video was made
        InputManager.GetInstance().RegisterSubmitPressed(); // this is specific to my InputManager script
        ContinueStory();
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
        // float characterColliderHeight = character.GetComponent<Collider2D>().bounds.size.y;
        // float characterRendererHeight = character.GetComponent<Renderer>().bounds.size.y;
        
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

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    this.talkingCharacter = GameObject.Find(tagValue);
                    break;
                case PORTRAIT_TAG:
                    if (this.talkingCharacter != null)
                    {
                        SpriteRenderer talkingSprite = talkingCharacter.GetComponent<SpriteRenderer>();
                        if (tagValue == "Coco_sad") 
                        {
                            talkingSprite.material.color = Color.blue;
                        }
                        else
                        {
                            talkingSprite.material.color = Color.yellow;
                        }
                    }
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