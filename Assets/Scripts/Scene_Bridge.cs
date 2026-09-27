using UnityEngine;
using System.Collections.Generic;

public class Scene_Bridge : MonoBehaviour
{
    private List<string> intro = new List<string>{"You find the ship’s command room and ultimately decide it’s far more boring than you expected. This ship is definitely one of the larger ones, and a glance at the consoles tells you it has some weapons capabilities, but there aren’t many people even in this room, and the Captain’s chair is empty.",
    "No one even cares that you’re meandering about, and you hear one person mumbling curses aimed at the navigation system as the others mumbles curses aimed at them, the navigator whining that it isn’t their fault and everyone making a variety of hissing noises in response."};

    void Start(){
        if (!Bookkeeper.bk.isIntroFinished("Bridge")){
            DialogueHandler.dh.showDialogueBox(intro);
            Bookkeeper.bk.finishIntro("Bridge");
        }
    }
}