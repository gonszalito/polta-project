using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCutscene : MonoBehaviour
{

    [SerializeField] private Animator animator;

    [Header ("Ink JSON")]

    // [SerializeField] private string[] dialogueName;
    [SerializeField] private TextAsset[] inkJSON;

    // [System.Serializable]
    // public class DialogueFiles
    // {
    //     public string dialogueName;
    //     public TextAsset inkJSON;
    // }
    // public DialogueFiles[] dialogueFiles;

    public bool isCutscene{ get; private set; }

    private static DialogueCutscene instance;

    private Dictionary<string, TextAsset> inkDictionary;

    public static DialogueCutscene GetInstance() 
    {
        return instance;
    }

    private void Awake() 
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Cutscene in the scene");
        }
        instance = this;
        this.isCutscene = false;
    }

    private void Start() 
    {
        inkDictionary = new Dictionary<string, TextAsset>();
        foreach (TextAsset textAsset in inkJSON)
        {
  
                inkDictionary[textAsset.name] = textAsset;
        }    
    }
    
    private void Update() 
    {
        // Debug.Log(inkTest.name);
    }

    public void PlayDialogue(string dialogueName){

            DialogueManager.GetInstance().EnterDialogueMode(inkDictionary[dialogueName]);
        
    }

    public void SetCutscene(bool isCutscene)
    {
        this.isCutscene = isCutscene;
    }
}