using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory inv;

    public List<string> looseItems; //unfound items
    public List<string> currItems; //display
    public List<string> usedItems; //do not display

    void Start(){
        inv = this;
        if (SaveData.sd.wasDataLoaded()){
            looseItems = new List<string>(SaveData.sd.getLooseItems());
            currItems = new List<string>(SaveData.sd.getCurrItems());
            usedItems = new List<string>(SaveData.sd.getUsedItems());
        }
        else{
            clearLists();
        }
    }

    protected internal List<string> getLooseItems(){
        return looseItems;
    }
    protected internal List<string> getCurrItems(){
        return currItems;
    }
    protected internal List<string> getUsedItems(){
        return usedItems;
    }

    protected internal bool isItemLoose(string item){
        for (int i=0; i<looseItems.Count; i++){
            if (looseItems[i].Equals(item)){
                return true;
            }
        }
        return false;
    }

    protected internal void addLooseItem(string path){
        looseItems.Add(path);
    }
    protected internal void addCurrItem(string path){
        currItems.Add(path);
    }
    protected internal void addUsedItem(string path){
        usedItems.Add(path);
    }
    protected internal void looseToCurrItem(string path){
        looseItems.Remove(path);
        addCurrItem(path);
        InventoryScene.isc.addItemToDisplay(path, path.Split("/", 2)[1]);
    }
    protected internal void currToUsedItem(string path){
        currItems.Remove(path);
        addUsedItem(path);
    }

    protected internal void clearLists(){
        looseItems = new List<string>{};
        currItems = new List<string>{};
        usedItems = new List<string>{};
    }
}