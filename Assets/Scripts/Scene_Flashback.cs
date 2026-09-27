using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Scene_Flashback : MonoBehaviour
{
    public TMP_Text text;
    public Image image;

    private int index = 0;

    // do not open this scene as a room
    // force move from mess hall to hallway after done

    private List<string> dialogue = new List<string>{
        "Just as you swallow the last of the glowing, slimy, crunchy concoction in a vain hope to recall something, you spot a crew member walking past the doorway in the hall, a clawed hand grasping a clear box with an ugly accessory, and…",
        "You recognize that bracelet.",
        "A flash of memory:",
        "<i>You're standing at a small stall in a crowded outdoor marketplace, the merchant leaning over the table and grasping your wrist with a bony... tentacle?\n\nYour gaze is stuck on the tentacle, actually, because it looks like a normal tentacle but you can feel the hard knobs of tiny bones encircling your wrist, and between that and the soft sort of oozy texture you're having full-body shudders.</i>",
        "<i>\"Listen well, little alien,\" the merchant hisses, another tentacle now sliding a dull, ugly sort of bracelet over your hand. \"You've fully ripened, and only this bracelet will conceal you from them. Do not remove it.\"\n\nYou stare at the eight eyes blinking out of sync, six of them focused on you and one watching to your right and the other seeming mostly asleep, and you want to run but the bony tentacle is still snug around your wrist. \"Conceal me from who, exactly?\"\n\n\"The wormholes, you fool,\" the merchant says, collapsing back into their seat and wiping the tentacles that had touched you on a napkin. \"Now begone. You're bad for business.\"</i>",
        "<i>You left the bracelet on lest the merchant’s many eyes notice you removed it, kind of forgot about it really, but then you spotted the dull gleam once you were in your quarters and chucked it off, tossed it out the door before it even closed behind you, and moments later you found yourself in the warm darkness.</i>",
        "You blink rapidly and are back in the bustling mess hall, the bracelet you apparently need to prevent being swallowed by wormholes vanishing down the hallway with the crew member. You hurry after them."
    };

    void Start(){
        text.text = dialogue[index];
        index++;
    }

    public void contFlashbackText(){
        if (dialogue.Count < index){
            text.text = dialogue[index];
            index++;
        }
        else{
            Bookkeeper.bk.haveFlashback();
            Scenes.sc.swapFlashback(true);
        }
    }
}
