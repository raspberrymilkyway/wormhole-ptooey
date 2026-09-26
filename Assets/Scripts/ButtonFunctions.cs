using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Is it great design to put literally all button functions in one file? No. Am I going to do it anyway? :)

public class ButtonFunctions : MonoBehaviour
{
    public static ButtonFunctions bf;
    public Image cursorImg;
    public string currentRoom;

    void Start(){
        bf = this;
    }

    public void startNewGame(){
        clearData();
        Scenes.sc.closeScene("Start");
        Scenes.sc.openScene("Cabin");
    }

    public void continueGame(){
        Scenes.sc.closeScene("Start");
        Scenes.sc.openScene(SaveData.sd.getCurrentRoom());
    }

    public void credits(){
        Scene_Start.sc_st.enableCredits();
    }

    public void endings(){
        Scene_Start.sc_st.enableEndings();
    }

    public void startBack(){
        Scene_Start.sc_st.disableCredits();
        Scene_Start.sc_st.disableEndings();
    }

    public void swapRoom(string goingTo){
        Scenes.sc.swapRooms(currentRoom, goingTo);
        hideCursor();
    }

    public void blurb(string blot){
        // spoken or thought?
        Debug.Log(blot);
        // this needs to be passed somewhere for later display
    }

    public void changeCursor(string name, bool swapBookkeeper=true){
        cursorImg.sprite = Resources.Load<Sprite>("cursors/" + name);
        cursorImg.gameObject.SetActive(true);
        Cursor.visible = false;
        if (swapBookkeeper){
            Bookkeeper.bk.setCurrentCursor(name);
        }
    }
    public void hideCursor(){
        cursorImg.gameObject.SetActive(false);
        Cursor.visible = true;
        Bookkeeper.bk.clearCurrentCursor();
    }

    public void tempFunction(){
        Debug.Log("temp");
    }

    private void clearData(){
        SaveData.sd.clearSaveData();
        Inventory.inv.clearLists();
        Bookkeeper.bk.clearEndings();
        Bookkeeper.bk.clearPoints();
    }
}
