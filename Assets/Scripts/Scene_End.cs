using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Scene_End : MonoBehaviour
{
    public TMP_Text titleTitle;
    public TMP_Text endTitle;
    public TMP_Text endBody;

    private List<List<string>> endings = new List<List<string>>{
        new List<string>{"Captain", "You're the Captain of this ship!\n\nThe Captain of course has access to the secure storage, so you reclaim the bracelet easily and never remove it again, and you spend your days guiding the ship around various solar systems with your loyal crew."},
        new List<string>{"Deserted", "You're caught trying to break into the secure storage!\n\nNo one can identify you, nor can they prove your intent, so you're deserted on the next planet they land on.\n\nYou manage to get hired on a new ship as the janitor, but since you failed to reclaim the bracelet... a wormhole snatches you up a few months into your flight.\n\nAfter the usual relaxing feeling of it consuming you, a voice very cheerfully informs you you're the nastiest thing it's ever tried, novel indeed, and promptly spits you out on a new ship that was nearby.\n\nThis ship is full of aliens who look nothing like you, and they immediately lock you up, though they at least provide you with... what may be food, and unwilling to even imply the food is nasty, as two wormholes have explicitly told you you are now, you eat it.\n\nWhatever it was was not meant to be consumed by your species, and as you lay slowly dying in the small cell, you mumble curses aimed at the rude wormholes and the vague merchant and the ugly bracelet."},
        new List<string>{"Diplomat", "You're the diplomat this ship was escorting!\n\nYou manage to convince everyone the bracelet is yours and they promptly return it to you and profusely apologize for taking it. You spend the rest of the flight studying what you need to know about your home planet so you don't mess up the negotiations you were on your way to handle before the wormhole ate you and rudely spit you out."},
        new List<string>{"Snatched", "You've nearly convinced the ship's crew you need the bracelet when they fly too near a wormhole.\n\nYou're gone a second later, somewhere dark and soothing, a familiar vibration rumbling through you and even your panic ebbing quickly as you begin to sink into the warmth flooding you.\n\n\"Ew! You really are gross!\" A voice says, excited and very happy even as the vibrations stop and you try and fail to open your eyes. \"I'd never heard of a ripe one being nasty until now, this is hilarious! I'll let everyone else know to try you too!\"\n\nYou're spit out on a new ship, this time, and the language isn't one you've heard or... hm, if it is, so much time has passed that now it isn't.\n\nYou don't have time to learn much before a new wormhole snatches you for a taste, this one also gleefully telling you how disgusting you are before spitting you out on some new ship, and the cycle continues."},
        new List<string>{"Space Pirate", "You're a pirate!\n\nHow could you ever forget your love of thievery and treasure?\n\nYou steal the bracelet back with practiced ease, slipping it onto your wrist and sighing a bit sadly at the lack of precious gemstones or sparkling metal, your greatest treasure not all that eye-catching, but you can't grow your hoard if you're constantly getting chewed up and spit out by wormholes.\n\nSafety secured, you can now return to your life of space piracy."},
        new List<string>{"Game Over", "Bomb Ending", "You have a strange feeling of apprehension, just as everything is about to be resolved one way or another, and your mind flashes back to the explosive device in the command room you chose to ignore.\n\nThen there’s a massive boom, and the ship rocks and splinters around you, and the cold of space seeps into your bones as death swiftly claims you, your last thought being that you never should have touched that device if you couldn’t disarm it."},
        new List<string>{"Game Over", "Bomb Ending", "Your last thought before the device detonates is that you cut the wrong wire, and then everything goes black."}
    };

    private int currentEnding = 0;

    void Start(){
        Bookkeeper.bk.setPreviousRoom("End");
        bool bomb = Bookkeeper.bk.getBombStatus();
        if (bomb){
            //ending failed to disarm
            currentEnding = 6;
        }
        else{
            int[] points = Bookkeeper.bk.getPoints();
            for (int i=1; i<points.Length; i++){
                if (points[i] > points[currentEnding]){
                    currentEnding = i;
                }
            }
        }

        replaceText();
    }

    private void replaceText(){
        if (currentEnding > 4){
            //bomb ending
            titleTitle.text = endings[currentEnding][0];
            endTitle.text = endings[currentEnding][1];
            endBody.text = endings[currentEnding][2];

            Bookkeeper.bk.finishEnding(5);
        }
        else{
            endTitle.text = endings[currentEnding][0];
            endBody.text = endings[currentEnding][1];

            Bookkeeper.bk.finishEnding(currentEnding);
        }
    }
}
