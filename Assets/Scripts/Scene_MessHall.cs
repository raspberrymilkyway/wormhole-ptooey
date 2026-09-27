using UnityEngine;
using System.Collections.Generic;

public class Scene_MessHall : MonoBehaviour
{
    private List<string> intro = new List<string>{"You're hungry, and ships like this probably have cafeterias?",
    "You find someone and ask where the food is, and a few very amused crew members point you in the right direction, one saying in a sort of rumbly voice that they also get forgetful when they're hungry and another clicking the little pincers on their face in what may be their species' equivalent of a tut.",
    "\"We spent a decade going in the wrong direction because our system malfunctioned, and you still do not know where the mess hall is?\" They drawl. \"Are you our navigator, per chance?\"",
    "\"Who knows?\" You ask, and then happily head down the hall they very tiredly point towards with their scythe-like appendage.",
    "You have a lovely meal, even if several people shoo you away from the most interesting dishes, one asking if you have a death wish and another saying a single bite of that will take ten years off your life if you’re lucky."};

    void Start(){
        if (!Bookkeeper.bk.isIntroFinished("MessHall1")){
            DialogueHandler.dh.showDialogueBox(intro);
            Bookkeeper.bk.finishIntro("MessHall1");
        }
    }
}