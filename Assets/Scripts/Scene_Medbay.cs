using UnityEngine;
using System.Collections.Generic;

public class Scene_Medbay : MonoBehaviour
{
    private List<string> intro = new List<string>{"Well, something is clearly wrong with you, so you go in search of a physician.", 
    "This ship has a few different species that you aren't dissimilar to, and they helpfully tell you which turns to take, one saying you do indeed look far too pale and another saying you must be flushed with a fever, and you just nod and thank them and scurry on your way.", 
    "Despite the size and variety of crew, the ship... only has a single medical bed, and no real physician in sight."};

    void Start(){
        if (!Bookkeeper.bk.isIntroFinished("Medbay")){
            DialogueHandler.dh.showDialogueBox(intro);
            Bookkeeper.bk.finishIntro("Medbay");
        }
    }
}