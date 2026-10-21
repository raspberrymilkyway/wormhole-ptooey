using UnityEngine;
using System;
using System.Collections.Generic;

public class Descriptions : MonoBehaviour
{
    public static Descriptions desc;

    private string itemFile = "itemDescriptions";
    private string characterFile = "characterDescriptions";

    private OuterDesc itemsDesc;
    private OuterDesc charsDesc;

    protected internal Dictionary<string, string> items = new Dictionary<string, string>{};
    protected internal Dictionary<string, string> chars = new Dictionary<string, string>{};

    void Start(){
        desc = this;
        
        TextAsset read = Resources.Load<TextAsset>(itemFile);
        itemsDesc = JsonUtility.FromJson<OuterDesc>(read.text);
        makeDict(true);
        
        read = Resources.Load<TextAsset>(characterFile);
        charsDesc = JsonUtility.FromJson<OuterDesc>(read.text);
        makeDict(false);
    }
    
    private void makeDict(bool item){
        if (item){
            for (int i=0; i<itemsDesc.room.Length; i++){
                eachDict(itemsDesc.room[i].itemPlus, item);
            }
        }
        else{
            for (int i=0; i<charsDesc.room.Length; i++){
                eachDict(charsDesc.room[i].itemPlus, item);
            }
        }
    }
    private void eachDict(string[] itemPlus, bool item){
        for (int i=0; i<itemPlus.Length; i++){
            int j = itemPlus[i].IndexOf(" - ");
            if (item){
                items[itemPlus[i].Substring(0, j)] = itemPlus[i].Substring(j+3);
            }
            else{
                chars[itemPlus[i].Substring(0, j)] = itemPlus[i].Substring(j+3);
            }
        }
    }
}

[Serializable]
public class OuterDesc
{
    public InnerDesc[] room;
}

[Serializable]
public class InnerDesc
{
    public string name;
    public string[] itemPlus;
}