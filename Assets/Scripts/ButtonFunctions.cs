using UnityEngine;
using UnityEngine.UI;

// Is it great design to put literally all button functions in one file? No. Am I going to do it anyway? :)

public class ButtonFunctions : MonoBehaviour
{
    public static ButtonFunctions bf;

    void Start(){
        bf = this;
    }

    public void startNewGame(){
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

    public void swapRoom(string current, string goingTo){
        Scenes.sc.swapRooms(current, goingTo);
    }

    public void blurb(string blot){
        // spoken or thought?
        Debug.Log(blot);
        // this needs to be passed somewhere for later display
    }

    public void changeCursor(string name){
        Texture2D c = Resources.Load<Texture2D>("cursors/" + name);
        UnityEngine.Cursor.SetCursor(c, Vector2.zero, CursorMode.Auto); //if using .ForceSoftware, brighten textures or swap types, uncheck sRGB, and accept the warnings
        Bookkeeper.bk.setCurrentCursor(name);
    }
}
