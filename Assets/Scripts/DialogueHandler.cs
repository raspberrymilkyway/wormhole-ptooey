using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public static DialogueHandler dh;

    public CanvasGroup holder;
    public CanvasGroup blocker;
    public TMP_Text dialogueBox;

    private List<string> dialogue;

    void Start(){
        dh = this;

        blocker.gameObject.SetActive(false);
        holder.gameObject.SetActive(true);
    }

    public void showDialogueBox(List<string> dialog){
        dialogue = dialog;
        blocker.gameObject.SetActive(true);
        holder.blocksRaycasts = false;
        handleDialogue();
    }
    public void hideDialogueBox(){
        blocker.gameObject.SetActive(false);
        holder.blocksRaycasts = true;
    }

    public void handleDialogue(){
        if (dialogue.Count > 0){
            dialogueBox.text = dialogue[0];
            dialogue.RemoveAt(0);
        }
        else{
            hideDialogueBox();
        }
    }
}