using UnityEngine;
using UnityEngine.UI;

public class Scene_Cabin : MonoBehaviour
{
    public static Scene_Cabin sc_ca;

    public CanvasGroup holder;
    public GameObject slime;
    public GameObject player;

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

        Debug.Log(Bookkeeper.bk.getPreviousRoom());
        if (Bookkeeper.bk.getPreviousRoom().Equals("Start") || Bookkeeper.bk.getPreviousRoom().Equals("Components")){
            player.transform.position = new Vector2(1920/2, 1080/2);
        }
    }
}