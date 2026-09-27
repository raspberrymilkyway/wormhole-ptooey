using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public static Scenes sc;

    void Start(){
        sc = this;
        openScene("Start");
    }

    protected internal void openScene(string scene){
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        Bookkeeper.bk.addOpenScene(scene);
    }
    protected internal void closeScene(string scene){
        SceneManager.UnloadSceneAsync(scene);
        Bookkeeper.bk.closeOpenScene(scene);
    }
    protected internal void swapRooms(string curr, string goTo){
        // only to be used after start is closed!
        closeScene(curr);
        openScene(goTo);
        SaveData.sd.saveData(); //should we save every time a room is swapped? check resource use
    }
    protected internal void swapFlashback(bool inFlashback){
        if (inFlashback){
            closeScene("Flashback");
            openScene("Hallway");
        }
        else{
            closeScene("MessHall4");
            openScene("Flashback");
        }
    }
    protected internal void swapCabin(){
        closeScene("IntroSequence");
        openScene("Cabin");
    }
}