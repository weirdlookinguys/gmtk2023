using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DialogueUI : MonoBehaviour
{

    private Dialogue dialogueObj;
    private Dictionary<string, string[,]> DialogueLibrary;
    private bool isDialogueActive = false;
    private int dialogueArraySize = 0;
    private int currentArrayLine = 0;
    private string currentLine = string.Empty;
    private string DialogueName = string.Empty;
    public TextMesh TextMeshUI;
    private int PersonTalking;

    void Start(){
        dialogueObj = FindObjectOfType<Dialogue>();
        DialogueLibrary = dialogueObj.GetDialogueLibrary();
        TextMeshUI.text = string.Empty;
        //InitializeDialogue("Introduction");
    }

    void Update(){
        if (isDialogueActive) {
            //Goes to Next Line when pressing space bar
            if (Input.GetKeyDown(KeyCode.Space) && currentArrayLine < dialogueArraySize - 1) {
                currentArrayLine++;
                TextMeshUI.text = DialogueLibrary[DialogueName][currentArrayLine, 0];
                PersonTalking = int.Parse(DialogueLibrary[DialogueName][currentArrayLine, 1]);
                TextMeshUI.color = PersonTalking == 1 ? Color.white : Color.gray;
            }
            else if(Input.GetKeyDown(KeyCode.Space) && currentArrayLine == dialogueArraySize - 1) {
                isDialogueActive = false;
                TextMeshUI.text = string.Empty;
            }
        }
        
    }

    public void InitializeDialogue(string dialogueName){
        isDialogueActive = true;
        DialogueName = dialogueName;
        dialogueArraySize = DialogueLibrary[dialogueName].GetLength(0);
        currentLine = DialogueLibrary[dialogueName][currentArrayLine, 0];
        TextMeshUI.text = DialogueLibrary[dialogueName][currentArrayLine, 0];
        PersonTalking = int.Parse(DialogueLibrary[dialogueName][currentArrayLine, 1]);
        TextMeshUI.color = PersonTalking == 1 ? Color.white : Color.gray;
    }

    public bool IsDialogueActive() {
        return isDialogueActive;
    }
}
