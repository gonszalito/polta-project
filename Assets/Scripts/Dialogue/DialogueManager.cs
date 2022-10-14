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
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header ("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;


    private Story currentStory;
    public bool dialogueIsPlaying { get; private set;}


    private static DialogueManager instance;

    private void Awake() 
    {
        if (instance != null)
        {
           Debug.LogWarning("Found more than one Dialogue Manager");
        }    
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start() {
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false);

            // get all of the choices text
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
        // return right away if dialogue isn't playing
        if (!dialogueIsPlaying)
        {
            return;
        } 

        //handle continuing to the next line in the dialogue when submit is pressed
        if (InputManager.GetInstance().GetInteractPressed())
        {
            ContinueStory();
            Debug.Log("interact continuer pressed");
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {   
            // dialoguePanel.SetActive(false);
            dialogueText.text = currentStory.Continue();
             // Debug.Log(dialogueText.text);
             DisplayChoices();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        int index = 0;
        choicesText[index].text = currentChoices[index].text;
        index++;
        
        StartCoroutine(SelectFirstChoice());
    }
    // go throu hte remaining choices the UI supports andmake sure they're hidden

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
        // if (canContinueToNextLine) 
        // {
            currentStory.ChooseChoiceIndex(choiceIndex);
            // NOTE: The below two lines were added to fix a bug after the Youtube video was made
            InputManager.GetInstance().RegisterSubmitPressed(); // this is specific to my InputManager script
            ContinueStory();
        // }
    }

}
