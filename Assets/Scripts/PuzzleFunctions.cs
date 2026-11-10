using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PuzzleFunctions : MonoBehaviour
{
    public static PuzzleFunctions pf;

    // add any successful print statements, i guess
    public GameObject puzzles;
    public GameObject puzzleBgGlasses;
    public GameObject bomb;
    public GameObject wave;
    public GameObject bodyAnchor;
    public GameObject puzzleCursor;
    public GameObject[] microNum = new GameObject[3];

    protected internal bool alreadySolved;
    private System.Random random = new System.Random();

    private bool open = true;
    private List<string> cookTime = new List<string>{};
    private Image[] microNumImg = new Image[3];

    private int colorIndex = 0;
    private string[] colors = new string[]{"red", "blue", "yellow"};
    private bool swapColor = true;
    private string currPart = "";
    private bool newImg = true;
    private RectTransform puzzleRT;
    private int hardCapNumParts = 1000;
    private int currNumParts = 0;
    private int currGS = 0;

    void Start(){
        pf = this;
        puzzles.SetActive(false);
        alreadySolved = ButtonFunctions.bf.isPuzzleSolved();
        if (microNum[0] != null){
            for (int i=0; i<microNum.Length; i++){
                microNumImg[i] = microNum[i].GetComponent<Image>();
            }
        }
        if (puzzleCursor != null){
            puzzleCursor.SetActive(false);
            puzzleRT = puzzleCursor.GetComponent<RectTransform>();
        }
    }

    public void showPuzzleWindow(){
        if (!alreadySolved){
            puzzles.SetActive(true);
        }
    }
    public void hidePuzzleWindow(){
        puzzles.SetActive(false);
    }

    public void cutIncorrectWire(){
        Bomb.bomb.detonate();
    }
    public void cutCorrectWire(){
        Bomb.bomb.defuse();
    }
    public void removeChip(){
        Bomb.bomb.defuse();
    }

    public void increaseAmplitude(){
        //
    }
    public void decreaseAmplitude(){
        //
    }
    public void increaseFrequency(){
        //
    }
    public void decreaseFrequency(){
        //
    }
    public void square(){
        //
    }
    public void sawtooth(){
        //
    }
    public void triangle(){
        //
    }
    public void sine(){
        //
    }

    public void medbayLabel(){
        //draggable
    }
    public void medbayButton(){
        //
    }

    public void microwaveDoor(){
        // open or close door
        open = !open;
    }
    public void microwaveButtonSans(){
        // do i need these? does interact interactable work?
    }
    public void microwaveButton(string num){
        if (cookTime.Count >= 3){
            return;
            // what do microwaves do with too many numbers?
            // would it be a better mechanic to just erase the highest number and move everything up?
        }
        cookTime.Insert(0, num);
        
        for (int i=0; i< cookTime.Count; i++){
            Debug.Log("microwave/numbers/numbers-" + cookTime[i]);
            microNumImg[2-i].sprite = Resources.Load<Sprite>("microwave/numbers/numbers-" + cookTime[i]);
        }
    }
    public void microwaveStart(){
        // on correct, do. something. we don't have visuals for this
        //      solve puzzle
    }
    public void addFood(){
        //???
    }

    public void blue(){
        swapColor = false;
        colorIndex = Array.IndexOf(colors, "blue");
        swapPuzzleCursor();
    }
    public void red(){
        swapColor = false;
        colorIndex = Array.IndexOf(colors, "red");
        swapPuzzleCursor();
    }
    public void yellow(){
        swapColor = false;
        colorIndex = Array.IndexOf(colors, "yellow");
        swapPuzzleCursor();
    }
    public void eraseAll(){
        while (bodyAnchor.transform.childCount > 0) {
            DestroyImmediate(bodyAnchor.transform.GetChild(0).gameObject);
        }
        ButtonFunctions.bf.hideCursor();
        currNumParts = 0;
    }
    public void flip(){
        if (currPart != ""){
            puzzleRT.localScale = new Vector3(puzzleRT.localScale.x*-1, 1, 1);
        }
    }
    public void grow(float amt=1.5f){
        if (currPart != "" && currGS < 5){
            puzzleRT.sizeDelta = new Vector3(puzzleRT.sizeDelta.x * amt, puzzleRT.sizeDelta.y * amt, 0);
            currGS++;
        }
    }
    public void layerDown(){
        //
    }
    public void layerUp(){
        //
    }
    public void shrink(float amt=1.5f){
        if (currPart != "" && currGS > -5){
            puzzleRT.sizeDelta = new Vector3(puzzleRT.sizeDelta.x / amt, puzzleRT.sizeDelta.y / amt, 0);
            currGS--;
        }
    }
    public void trash(){
        currPart = "";
        swapColor = true;
        newImg = true;
        puzzleRT.localScale = new Vector3(1, 1, 1);
        swapPuzzleCursor();
    }
    public void antenna(){
        currPart = "assembly-antenna";
        handlePartClick();
    }
    public void arm(){
        currPart = "assembly-arm";
        handlePartClick();
    }
    public void eye(){
        currPart = "assembly-eye";
        handlePartClick();
    }
    public void head(){
        currPart = "assembly-head";
        handlePartClick();
    }
    public void leg(){
        currPart = "assembly-leg";
        handlePartClick();
    }
    public void mouth(){
        currPart = "assembly-mouth";
        handlePartClick();
    }
    public void tail(){
        currPart = "assembly-tail";
        handlePartClick();
    }
    public void torso(){
        currPart = "assembly-torso";
        handlePartClick();
    }

    private void handlePartClick(){
        if (swapColor){
            colorIndex = colorIndex+1 > 2 ? 0 : colorIndex+1;
            if (colorIndex == 0){
                shuffle();
            }
        }
        
        newImg = true;
        swapPuzzleCursor();
    }
    private void shuffle(){
        int i = colors.Length;
        while (i > 1){
            int t = random.Next(i);
            i--;
            string temp = colors[t];
            colors[t] = colors[i];
            colors[i] = temp;
        }
    }
    private void swapPuzzleCursor(){
        if (currPart != ""){
            string s = "medbed/assembly/" + currPart;
            s = currPart.Equals("assembly-mouth") || currPart.Equals("assembly-eye") ? s : s + "-" + colors[colorIndex];
            Image img = puzzleCursor.GetComponent<Image>();
            img.sprite = Resources.Load<Sprite>(s);
            if (newImg){
                img.SetNativeSize();
                newImg = false;
                puzzleRT.localScale = new Vector3(1, 1, 1);
            }
            puzzleCursor.SetActive(true);
        }
        else{
            puzzleCursor.SetActive(false);
        }
    }
    public void addImage(){
        if (currNumParts >= hardCapNumParts || currPart.Equals("")){
            return; //maxed. stop adding stuff.
        }

        GameObject go = new GameObject();
        go.name = currPart;

        Image igo = go.AddComponent<Image>();
        string s = "medbed/assembly/" + currPart;
        s = currPart.Equals("assembly-mouth") || currPart.Equals("assembly-eye") ? s : s + "-" + colors[colorIndex];
        igo.sprite = Resources.Load<Sprite>(s);
        go.AddComponent(typeof(IHatJHat.UI.HideInvisible));

        RectTransform rgo = go.GetComponent<RectTransform>();
        rgo.SetParent(bodyAnchor.transform);
        rgo.sizeDelta = puzzleRT.sizeDelta;
        rgo.position = puzzleRT.position;
        rgo.localScale = puzzleRT.localScale;

        go.SetActive(true);
        currNumParts++;
    }
}