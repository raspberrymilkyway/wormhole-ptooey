using UnityEngine;
using System.Collections.Generic;

//...this text is not structured the same way

public class Scene_CaptainQuarters : MonoBehaviour
{
    private List<string> intro = new List<string>{};

    void Start(){
        if (!Bookkeeper.bk.isIntroFinished("CaptainQuarters")){
            DialogueHandler.dh.showDialogueBox(intro);
            Bookkeeper.bk.finishIntro("CaptainQuarters");
        }
    }
}