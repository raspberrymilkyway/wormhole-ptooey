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
    public GameObject dialogueStyle;
    public TMP_Text[] styleFlavorText = new TMP_Text[5];

    private List<List<string>> all;
    private int[] points;
    private List<string> dialogue;

    void Start(){
        dh = this;

        blocker.gameObject.SetActive(false);
        holder.gameObject.SetActive(true);
        dialogueStyle.SetActive(false);
    }

    public void showDialogueStyle(List<string> flavors, List<List<string>> strings, int[] pts){
        for (int i=0; i<flavors.Count; i++){
            styleFlavorText[i].text = flavors[i];
        }
        dialogueStyle.SetActive(true);
        holder.blocksRaycasts = false;
        all = strings;
        points = pts;
    }

    public void showDialogueBox(List<string> dialog, int index){
        dialogue = dialog;
        dialogueStyle.SetActive(false);
        blocker.gameObject.SetActive(true);
        holder.blocksRaycasts = false;
        Bookkeeper.bk.addPoints(index, points[index]);
        handleDialogue();
    }
    public void hideDialogueBox(){
        blocker.gameObject.SetActive(false);
        dialogueStyle.SetActive(false);
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

    public void setStyle(int style){
        showDialogueBox(all[style], style);
    }
}