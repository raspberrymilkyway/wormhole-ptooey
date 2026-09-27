using UnityEngine;
using System.Collections.Generic;

//...this text is not structured the same way

public class Scene_CaptainQuarters : MonoBehaviour
{
    private List<string> intro = new List<string>{"You haven’t seen a trace of the ship’s Captain, but when you spot what must be their quarters, you find yourself staring at the door, because, well...",
    "This ship is large, and you’ve heard nothing of the Captain, and you’re here and wandering about freely so... maybe you’re the Captain?"};

    void Start(){
        if (!Bookkeeper.bk.isIntroFinished("CaptainQuarters")){
            DialogueHandler.dh.showDialogueBox(intro);
            Bookkeeper.bk.finishIntro("CaptainQuarters");
        }
    }
}