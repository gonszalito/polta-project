using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMover : MonoBehaviour
{
    private GameObject dialogueBox;
    private Camera cam;

    public DialogueMover(GameObject dialogueBox, Camera cam)
    {
        this.dialogueBox = dialogueBox;
        this.cam = cam;
    }

    // Start is called before the first frame update
    public void SetDialogueOnTalkingCharacter()
    {
        GameObject character;
        // Get the dialogue line
        // Search the GameObject of the character in the Scene
        character = GameObject.Find("Player");
        // Sets the dialogue position
        SetDialoguePosition(character);
    }

    private void SetDialoguePosition(GameObject character)
    {
        // Retrieve the position where the top part of the sprite is in the world
        float characterSpriteHeight = character.GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

        // Create position with the sprite top location
        Vector3 characterPosition = new Vector3(character.transform.position.x,
                                                characterSpriteHeight,
                                                character.transform.position.z);

        // Set the DialogueBubble position to the sprite top location in Screen Space
        this.transform.position = cam.WorldToScreenPoint(characterPosition);
    }
}
