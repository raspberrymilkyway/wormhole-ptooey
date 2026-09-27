using UnityEngine;
using UnityEngine.UI;

public class Scene_Cabin : MonoBehaviour
{
    public static Scene_Cabin sc_ca;

    public CanvasGroup holder;
    public GameObject slime;

    // if prev in hallway
    // add slime. can only click slime and door (leave)
    // (if door, can keep repeating this)
    // slime dialogue keeper
    // move to the door
    // swap bookkeeper canentercabin to false
    // leave room

    void Start(){
        sc_ca = this;

        if (Bookkeeper.bk.getPreviousRoom().Equals("Hallway")){
            slime.SetActive(true);
        }
        else{
            slime.SetActive(false);
        }
    }
}