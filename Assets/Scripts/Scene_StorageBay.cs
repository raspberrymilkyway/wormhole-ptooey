using UnityEngine;
using System.Collections.Generic;

public class Scene_StorageBay : MonoBehaviour{
    public GameObject glasses;
    public GameObject extraneousLabelButtons;
    public GameObject initial;

    private List<string> intro = new List<string>{"You need that bracelet, and so you need to enter the locked storage bay."};

    void Start(){
        if (Inventory.inv.isItemCurr("glasses")){ //placeholder name
            initial.SetActive(false);
            glasses.SetActive(true);
            extraneousLabelButtons.SetActive(true);
        }
        else{
            initial.SetActive(true);
            glasses.SetActive(false);
            extraneousLabelButtons.SetActive(false);
        }

        if (!Bookkeeper.bk.isIntroFinished("StorageBay")){
            DialogueHandler.dh.showDialogueBox(intro);
            Bookkeeper.bk.finishIntro("StorageBay");
        }
    }
}