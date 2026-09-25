using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryInteractable: MonoBehaviour
{
    public string functionToCall = "";
    public GameObject manager;
    public GameObject cursorImg;
    public string[] interactableItems = new string[]{};

    void Start(){
        if (this.GetComponent<Button>() != null){
            this.GetComponent<Button>().onClick.AddListener(() => cursorReset());
        }
    }

    // click on with custom cursor of x item
    public void OnPointerClick(){
        // use w/ colliders for non-button cases. will there be non-button cases? don't know.
        cursorReset();
    }

    protected internal bool goodInteraction(string cursor){
        if (Array.IndexOf(interactableItems, cursor) > -1){
            return true;
        }
        return false;
    }

    protected internal void cursorReset(){
        string cursor = Bookkeeper.bk.getCurrentCursor();
        if (cursor.Equals("")){
            return;
        }
        
        if (goodInteraction(cursor)){
            manager.SendMessage(functionToCall);
        }
        else{
            Debug.Log("thought bubble: didn't work.");
        }

        ButtonFunctions.bf.hideCursor();
    }
}