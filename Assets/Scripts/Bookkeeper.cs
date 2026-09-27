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
    private List<string> puzzleRoomsSolved = new List<string>{};
    private bool[] endings = new bool[6];
    private int[] points = new int[6];
    private string cursor = "";
    private string directionEnteredFrom = "";
    private string previousRoom = "";
    private bool detonatedBomb = false;
    private bool defusedBomb = false;
    private bool canEnterCabin = true;
    private bool hadFlashback = false;
    private bool[] intros = new bool[7];
    private Dictionary<string, int> introRooms = new Dictionary<string, int>{{"Cabin", 0}, {"CaptainQuarters", 1}, {"StorageBay", 2}, {"Medbay", 3}, {"MessHall1", 4}, {"MessHall2", 4}, {"MessHall3", 4}, {"MessHall4", 4}, {"Bridge", 5}, {"Hallway", 6}}; //should the messhalls be the same value?

    void Start(){
        bk = this;

        endings = SaveData.sd.getAchievedEndings();
        points = SaveData.sd.getPoints();
        previousRoom = SaveData.sd.getPreviousRoom();
        spokenTo = new List<string>(SaveData.sd.getSpokenTo());
        defusedBomb = SaveData.sd.getDefusedBomb();
        intros = SaveData.sd.getIntrosFinished();
        puzzleRoomsSolved = new List<string>(SaveData.sd.getPuzzlesSolved());
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

    protected internal void finishIntro(string room){
        intros[introRooms[room]] = true;
    }
    protected internal bool isIntroFinished(string room){
        return intros[introRooms[room]];
    }
    protected internal bool[] getIntrosFinished(){
        return intros;
    }
    protected internal void resetFinishedIntros(){
        intros = new bool[7];
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

    protected internal void detonateBomb(){
        detonatedBomb = true;
    }
    protected internal void defuseBomb(){
        defusedBomb = true;
        setPuzzleSolved("Bridge");
    }
    protected internal (bool, bool) getBombStatus(){
        return (detonatedBomb, defusedBomb);
    }
    protected internal void resetBomb(){
        detonatedBomb = false;
        defusedBomb = false;
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

    protected internal bool getHadFlashback(){
        return hadFlashback;
    }
    protected internal void haveFlashback(){
        hadFlashback = true;
    }
    protected internal void resetFlashback(){
        hadFlashback = false;
    }

    protected internal void setPuzzleSolved(string room){
        puzzleRoomsSolved.Add(room);
    }
    protected internal bool isPuzzleSolved(string room){
        return puzzleRoomsSolved.Contains(room);
    }
    protected internal List<string> getPuzzlesSolved(){
        return puzzleRoomsSolved;
    }
    protected internal void resetPuzzleStates(){
        puzzleRoomsSolved = new List<string>{};
    }

    protected internal bool checkWin(){
        // verify no other win conditions (any other way to get bracelet)
        if (Inventory.inv.isItemCurr("inventory/bracelet") || Inventory.inv.isItemCurr("bracelet")){
            Debug.Log("won!");
            return true;
        }
        return false;
    }

    protected internal void resetBookkeeperStats(){
        resetBomb();
        resetSpokenTo();
        resetCabinState();
        resetFlashback();
        resetPuzzleStates();
        clearPoints();
        setPreviousRoom("");
        setDirectionEnteredFrom("");
        resetFinishedIntros();
    }
}
