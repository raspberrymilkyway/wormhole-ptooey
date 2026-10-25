using UnityEngine;
using System;
using System.Collections.Generic;

public class Descriptions : MonoBehaviour
{
    public static Descriptions desc;

    private string itemFile = "itemDescriptions";
    private string characterFile = "characterDescriptions";

    protected internal Dictionary<string, string> items = new Dictionary<string, string>{};
    protected internal Dictionary<string, string> chars = new Dictionary<string, string>{};

    void Start(){
        desc = this;
        
        TextAsset read = Resources.Load<TextAsset>(itemFile);
        OuterDesc itemsDesc = JsonUtility.FromJson<OuterDesc>(read.text);
        makeDict(itemsDesc, true);
        
        read = Resources.Load<TextAsset>(characterFile);
        itemsDesc = JsonUtility.FromJson<OuterDesc>(read.text);
        makeDict(itemsDesc, false);
    }
    
    private void makeDict(OuterDesc itemsDesc, bool item){
        for (int i=0; i<itemsDesc.room.Length; i++){
            eachDict(itemsDesc.room[i].itemPlus, item);
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