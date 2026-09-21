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
}