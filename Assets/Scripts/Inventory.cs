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
        currItems = new List<string>{};
        usedItems = new List<string>{};
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