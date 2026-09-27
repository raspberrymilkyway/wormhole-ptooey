using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Scene_IntroSequence : MonoBehaviour
{
    public Image space;
    public Image wormhole;
    public TMP_Text body;
    public GameObject eyes;
    
    private bool skipDialogue = false;
    private List<string> intro = new List<string>{"A vast darkness surrounds you, comforting and soothing, and vibrations rumble through you, like some great purring creature is just at your back.", 
    "You can feel your mind drifting as your body pleasantly sinks down down down, all your worries, fears, and inadequacies melting away and leaving you feeling... warm and content, the best you've ever felt, really.",
    "\"Oh ew. Ew ew ew ew ew,\" the voice disrupts your peace, and the vibrations abruptly vanish. \"There's something wrong with this one, I'd better get rid of it and warn the others, gross.\"",
    "The darkness and warmth vanish, and you gasp when you fall onto a plush carpet, strange, hardened spikes of it digging into your back.",
    "Your eyes snap open and you groan as brightness blinds you, heaving yourself up and look around the... ship cabin?",
    "You slowly realize you have no idea where you are, or even who you are. Should you... even be here?"};
    private List<(string, string)> bgs = new List<(string, string)>{("", "opening-sequence/opening-mc-1"), ("", "opening-sequence/opening-mc-2"), ("opening-sequence/cabin", "opening-sequence/opening-mc-fallen"), ("", ""), ("", "")};

    void Start(){
        bool[] ends = Bookkeeper.bk.getEndings();
        for (int i=0; i<ends.Length; i++){
            if (ends[i]){
                skipDialogue = true;
                break;
            }
        }

        if (skipDialogue){
            body.gameObject.SetActive(false);
        }
        else{
            body.text = intro[0];
            intro.RemoveAt(0);
        }
    }

    public void contIntroText(){
        if (!skipDialogue && intro.Count > 0){
            body.text = intro[0];
            intro.RemoveAt(0);
            swapBg(bgs[0].Item1, bgs[0].Item2);
            bgs.RemoveAt(0);
        }
        else{
            Scenes.sc.swapCabin();
        }
    }

    private void swapBg(string bg, string swirl){
        if (!bg.Equals("")){
            space.sprite = Resources.Load<Sprite>(bg);
        }
        if (!swirl.Equals("")){
            wormhole.sprite = Resources.Load<Sprite>(swirl);
        }
        else{
            // last transition
            eyes.SetActive(true);
        }
    }
}