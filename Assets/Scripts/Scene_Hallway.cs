using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Scene_Hallway : MonoBehaviour
{
    public GameObject door4;
    public GameObject snob;
    // handle directional movement - fetch from bookkeeper

    private List<string> intro = new List<string>{"You exit the cabin room and spot a person in what you decide is a soldier's uniform."};

    void Start(){
        bool flash = Bookkeeper.bk.getHadFlashback();
        bool snoot = Bookkeeper.bk.alreadySpokenTo("Snob");
        if (snoot){
            door4.SetActive(true);
        }
        else if (flash){
            snob.SetActive(true);
        }
        else{
            snob.SetActive(false);
            door4.SetActive(false);
        }

        if (!Bookkeeper.bk.isIntroFinished("Hallway")){
            DialogueHandler.dh.showDialogueBox(intro);
            Bookkeeper.bk.finishIntro("Hallway");
        }

        if (!Bookkeeper.bk.isIntroFinished("Cabin")){
            Bookkeeper.bk.finishIntro("Cabin");
        }
    }
}