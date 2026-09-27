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
    private List<string> flavors;
    private bool pre;

    void Start(){
        dh = this;

        blocker.gameObject.SetActive(false);
        holder.gameObject.SetActive(true);
        dialogueStyle.SetActive(false);
    }

    public void showDialogueStyle(){
        for (int i=0; i<flavors.Count; i++){
            styleFlavorText[i].text = flavors[i];
        }
        dialogueStyle.SetActive(true);
        blocker.gameObject.SetActive(false);
        holder.blocksRaycasts = false;
    }

    public void showDialogueBox(List<string> dialog, int index=-1){
        dialogue = dialog;
        dialogueStyle.SetActive(false);
        blocker.gameObject.SetActive(true);
        holder.blocksRaycasts = false;
        if (index > -1){
            Bookkeeper.bk.addPoints(index, points[index]);
        }
        handleDialogue();
    }
    public void hideDialogueBox(){
        if (Bookkeeper.bk.getCurrentScene().Equals("Cabin")){
            // the only dialogue is with the slime, i think
            Bookkeeper.bk.removeCabin();
            ButtonFunctions.bf.swapRoom("Hallway");
        }
        else{
            blocker.gameObject.SetActive(false);
            dialogueStyle.SetActive(false);
            holder.blocksRaycasts = true;
        }
    }

    public void handleDialogue(){
        if (dialogue.Count > 0){
            dialogueBox.text = dialogue[0];
            dialogue.RemoveAt(0);
        }
        else if (pre){
            showDialogueStyle();
            pre = false;
        }
        else{
            hideDialogueBox();
        }
    }

    public void setStyle(int style){
        showDialogueBox(all[style], style);
    }

    public void preInput(List<string> pretext, List<string> flav, List<List<string>> strings, int[] pts){
        blocker.gameObject.SetActive(true);
        holder.blocksRaycasts = false;
        dialogue = pretext;
        pre = true;
        all = strings;
        points = pts;
        flavors = flav;
        handleDialogue();
    }
}