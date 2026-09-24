using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory inv;

    private List<string> looseItems; //unfound items
    private List<string> currItems; //display
    private List<string> usedItems; //do not display

    void Start(){
        inv = this;
        looseItems = new List<string>{"inventory/junk_item4"};
        currItems = new List<string>{"inventory/junk_item1", "inventory/junk_item2", "inventory/junk_item3", "inventory/junk_item4", "inventory/junk_item5", "inventory/junk_item5"};
        usedItems = new List<string>{"inventory/junk_item5"};
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
        looseItems.Add(path);
        addCurrItem(path);
    }
    protected internal void currToUsedItem(string path){
        currItems.Remove(path);
        addUsedItem(path);
    }
}