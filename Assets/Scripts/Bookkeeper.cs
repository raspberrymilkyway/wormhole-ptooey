using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

// To be real honest, I hate namespaces. Not using anything 3rd party, so only the (general purpose, pre-developed) UI pieces are gonna have namespaces

public class Bookkeeper : MonoBehaviour
{
    public static Bookkeeper bk;

    public Camera cam;

    public List<string> openScenes = new List<string>(){"Components"};
    private List<string> allItems = new List<string>{}; //path
    private bool[] endings = new bool[6];
    private string cursor = "";

    void Start(){
        bk = this;
    }

    protected internal void addOpenScene(string scene){
        openScenes.Add(scene);
    }
    protected internal List<string> getOpenScenes(){
        return openScenes;
    }
    protected internal void closeOpenScene(string scene){
        openScenes.Remove(scene);
    }
    protected internal bool isSceneOpen(string scene){
        return openScenes.Contains(scene);
    }
    protected internal string getCurrentScene(){
        return openScenes[openScenes.Count-1];
    }

    protected internal bool[] getEndings(){
        return endings;
    }

    protected internal Camera getCamera(){
        return cam;
    }

    protected internal void setCurrentCursor(string name){
        cursor = name;
    }
    protected internal void clearCurrentCursor(){
        cursor = "";
    }
}
