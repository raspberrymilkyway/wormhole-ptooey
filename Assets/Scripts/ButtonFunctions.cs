using UnityEngine;

// Is it great design to put literally all button functions in one file? No. Am I going to do it anyway? :)

public class ButtonFunctions : MonoBehaviour
{
    public void startGame(){
        Scenes.sc.closeScene("Start");
        Scenes.sc.openScene("Cabin");
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
}
