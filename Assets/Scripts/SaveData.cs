using UnityEngine;
using System.IO;
using System;

// Save data should not be stored with persistant path or PlayerPrefs if we're planning on updating it, but this is a jam and I've never uploaded anything on itch before, so. Normal saving measures it is!

public class SaveData : MonoBehaviour
{
    public static SaveData sd;

    private string path;
    private Progress progress;
    private bool loadedData = false;

    void Start(){
        sd = this;
        path = Application.persistentDataPath + "/save.json";
        progress = new Progress();

        if (File.Exists(path)){
            loadSaveData();
        }
        else{
            progress.points = new int[6];
            progress.looseInvData = new string[]{};
            progress.currInvData = new string[]{};
            progress.usedInvData = new string[]{};
            progress.achievedEndings = new bool[6];
            progress.currentRoom = "Cabin";
        }
    }

    protected internal void saveData(){
        if (File.Exists(path)){
            deleteSaveData();
        }
        updateInventory();
        updateCurrentRoom();
        updatePoints();
        updateEndings();
        string data = JsonUtility.ToJson(progress);
        File.WriteAllText(path, data);
    }
    protected internal void loadSaveData(){
        string load = File.ReadAllText(path);
        progress = JsonUtility.FromJson<Progress>(load);
        loadedData = true;
    }
    protected internal void deleteSaveData(){
        File.Delete(path);
    }
    protected internal bool wasDataLoaded(){
        return loadedData;
    }

    protected internal void updateInventory(){
        progress.looseInvData = Inventory.inv.getLooseItems().ToArray();
        progress.currInvData = Inventory.inv.getCurrItems().ToArray();
        progress.usedInvData = Inventory.inv.getUsedItems().ToArray();
    }
    protected internal void updateCurrentRoom(){
        progress.currentRoom = Bookkeeper.bk.getCurrentScene();
    }
    protected internal void updatePoints(){
        progress.points = Bookkeeper.bk.getPoints();
    }
    protected internal void updateEndings(){
        progress.achievedEndings = Bookkeeper.bk.getEndings();
    }

    protected internal string[] getLooseItems(){
        return progress.looseInvData;
    }
    protected internal string[] getCurrItems(){
        return progress.currInvData;
    }
    protected internal string[] getUsedItems(){
        return progress.usedInvData;
    }

    protected internal int[] getPoints(){
        return progress.points;
    }

    protected internal bool[] getAchievedEndings(){
        return progress.achievedEndings;
    }

    protected internal string getCurrentRoom(){
        return progress.currentRoom;
    }

    protected internal void clearSaveData(){
        progress.points = new int[6];
        progress.looseInvData = new string[]{};
        progress.currInvData = new string[]{};
        progress.usedInvData = new string[]{};
        progress.achievedEndings = new bool[6];
        progress.currentRoom = "Cabin";
        deleteSaveData();
    }
}

[Serializable]
public class Progress
{
    public int[] points;
    public string[] looseInvData;
    public string[] currInvData;
    public string[] usedInvData;
    public bool[] achievedEndings;
    public string currentRoom;
    //do we need like. a dialogue saver? how are our interactions interacting?
}
