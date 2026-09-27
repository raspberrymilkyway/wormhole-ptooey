using UnityEngine;
using System.Collections.Generic;

public class Scene_StorageBay : MonoBehaviour{
    public GameObject glasses;
    public GameObject extraneousLabelButtons;
    public GameObject initial;

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
            Bookkeeper.bk.finishIntro("StorageBay");
        }
    }
}