using UnityEngine;

// Is it great design to put literally all button functions in one file? No. Am I going to do it anyway? :)

public class ButtonFunctions : MonoBehaviour
{
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

    public void blurb(string blurb, bool speaking){
        // spoken or thought - true for spoken, false for thought
        Debug.Log(blurb);
        //edit - this needs to be passed somewhere for later display
    }
}
