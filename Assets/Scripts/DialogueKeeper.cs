using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

// For applying to an element

public class DialogueKeeper : MonoBehaviour, IPointerClickHandler
{
    public static DialogueKeeper dk;

    [Header("Strings")]
    public List<string> style1;
    public List<string> style2;
    public List<string> style3;
    public List<string> style4;
    public List<string> style5;

    [Header("Using the Strings?")]
    public bool string1;
    public bool string2;
    public bool string3;
    public bool string4;
    public bool string5;

    void Start(){
        dk = this;
    }

    public void OnPointerClick(PointerEventData eventData){
        if (string1){
            DialogueHandler.dh.showDialogueBox(style1);
        } else if (string2){
            DialogueHandler.dh.showDialogueBox(style2);
        } else if (string2){
            DialogueHandler.dh.showDialogueBox(style3);
        } else if (string2){
            DialogueHandler.dh.showDialogueBox(style4);
        } else {
            DialogueHandler.dh.showDialogueBox(style5);
        }
    }
}