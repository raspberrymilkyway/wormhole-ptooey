using UnityEngine;
using System;

// For applying to an element

public class DialogueKeeper : MonoBehaviour
{
    public static DialogueKeeper dk;

    [Header("Strings")]
    public string style1;
    public string style2;
    public string style3;
    public string style4;
    public string style5;

    [Header("Using the Strings?")]
    public bool string1;
    public bool string2;
    public bool string3;
    public bool string4;
    public bool string5;

    void Start(){
        dk = this;
    }
}