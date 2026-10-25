using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class PuzzleFunctions : MonoBehaviour
{
    public static PuzzleFunctions pf;

    // add any successful print statements, i guess
    public GameObject puzzles;
    public GameObject puzzleBgGlasses;
    public GameObject bomb;
    public GameObject wave;
    public GameObject[] microNum = new GameObject[3];

    protected internal bool alreadySolved;

    private bool open = true;
    private List<string> cookTime = new List<string>{};
    private Image[] microNumImg = new Image[3];

    void Start(){
        pf = this;
        puzzles.SetActive(false);
        alreadySolved = ButtonFunctions.bf.isPuzzleSolved();
        if (microNum[0] != null){
            for (int i=0; i<microNum.Length; i++){
                microNumImg[i] = microNum[i].GetComponent<Image>();
            }
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
}