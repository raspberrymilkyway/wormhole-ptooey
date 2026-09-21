using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public void StartGame(){
        Scenes.sc.openScene("Hallway"); //temp filler. dunno where we spawn yet.
        Scenes.sc.closeScene("Start");
    }

    public void Credits(){
        // do. something.
    }

    public void Endings(){
        // 
    }
}
