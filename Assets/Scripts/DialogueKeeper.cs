using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

// For applying to an element

public class DialogueKeeper : MonoBehaviour, IPointerClickHandler
{
    public static DialogueKeeper dk;
    public string characterName;

    [Header("Strings")]
    public List<string> style1;
    public List<string> style2;
    public List<string> style3;
    public List<string> style4;
    public List<string> style5;

    [Header("Flavor")]
    public List<string> flavors = new List<string>{"", "", "", "", ""};
    
    [Header("Pretext")]
    public List<string> pretext = new List<string>{};

    [Header("Points")]
    public int[] points = new int[5]{10, 10, 10, 10, 10};

    void Start(){
        dk = this;
        if (Bookkeeper.bk.alreadySpokenTo(characterName)){
            this.enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData){
        // DialogueHandler.dh.showDialogueStyle(flavors, new List<List<string>>{style1, style2, style3, style4, style5}, points);
        DialogueHandler.dh.preInput(pretext, flavors, new List<List<string>>{style1, style2, style3, style4, style5}, points);
        Bookkeeper.bk.addSpokenTo(characterName);
        this.enabled = false;
    }

    public void click(){
        DialogueHandler.dh.preInput(pretext, flavors, new List<List<string>>{style1, style2, style3, style4, style5}, points);
        Bookkeeper.bk.addSpokenTo(characterName);
        this.enabled = false;
    }
}