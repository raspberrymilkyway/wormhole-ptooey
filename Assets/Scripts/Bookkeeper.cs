using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

// To be real honest, I hate namespaces. Not using anything 3rd party, so only the (general purpose, pre-developed) UI pieces are gonna have namespaces

public class Bookkeeper : MonoBehaviour
{
    public static Bookkeeper bk;

    public Camera cam;

    public List<string> openScenes = new List<string>(){"Components"};
    private List<string> spokenTo = new List<string>{};
    private bool[] endings = new bool[6];
    private int[] points = new int[6];
    private string cursor = "";
    private string directionEnteredFrom = "";
    private string previousRoom = "";
    private bool detonatedBomb = false;
    private bool canEnterCabin = true;

    void Start(){
        bk = this;

        endings = SaveData.sd.getAchievedEndings();
        points = SaveData.sd.getPoints();
        previousRoom = SaveData.sd.getPreviousRoom();
        spokenTo = new List<string>(SaveData.sd.getSpokenTo());
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

    protected internal void finishEnding(int index){
        endings[index] = true;
    }
    protected internal bool[] getEndings(){
        return endings;
    }
    protected internal void clearEndings(){
        endings = new bool[6];
    }

    protected internal void addPoints(int index, int pts){
        points[index] += pts;
    }
    protected internal int[] getPoints(){
        return points;
    }
    protected internal void clearPoints(){
        points = new int[6];
    }

    protected internal Camera getCamera(){
        return cam;
    }

    protected internal void setCurrentCursor(string name){
        cursor = name;
    }
    protected internal string getCurrentCursor(){
        return cursor;
    }
    protected internal void clearCurrentCursor(){
        cursor = "";
    }

    protected internal void setDirectionEnteredFrom(string direction){
        directionEnteredFrom = direction;
        previousRoom = getCurrentScene();
    }
    protected internal string getDirectionEnteredFrom(){
        return directionEnteredFrom;
    }
    protected internal string getPreviousRoom(){
        return previousRoom;
    }
    protected internal void setPreviousRoom(string room){
        previousRoom = room;
    }

    protected internal void triggerBomb(){
        points[5] = 1000000;
    }
    protected internal void detonateBomb(){
        detonatedBomb = true;
    }
    protected internal bool getBombStatus(){
        return detonatedBomb;
    }
    protected internal void resetBomb(){
        detonatedBomb = false;
    }

    protected internal void addSpokenTo(string character){
        spokenTo.Add(character);
    }
    protected internal bool alreadySpokenTo(string character){
        return spokenTo.Contains(character);
    }
    protected internal List<string> getSpokenTo(){
        return spokenTo;
    }
    protected internal void resetSpokenTo(){
        spokenTo = new List<string>{};
    }

    protected internal bool getCabinState(){
        return canEnterCabin;
    }
    protected internal void removeCabin(){
        canEnterCabin = false;
    }
    protected internal void resetCabinState(){
        canEnterCabin = true;
    }

    protected internal void resetBookkeeperStats(){
        resetBomb();
        resetSpokenTo();
        resetCabinState();
        clearPoints();
        setPreviousRoom("");
        setDirectionEnteredFrom("");
    }
}
