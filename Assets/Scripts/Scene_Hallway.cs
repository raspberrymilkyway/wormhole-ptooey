using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Scene_Hallway : MonoBehaviour
{
    public GameObject door4;
    // handle directional movement - fetch from bookkeeper

    private List<string> intro = new List<string>{"You exit the cabin room and spot a person in what you decide is a soldier's uniform."};

    void Start(){
        door4.SetActive(Bookkeeper.bk.getHadFlashback());

        if (!Bookkeeper.bk.isIntroFinished("Hallway")){
            DialogueHandler.dh.showDialogueBox(intro);
            Bookkeeper.bk.finishIntro("Hallway");
        }
    }
}