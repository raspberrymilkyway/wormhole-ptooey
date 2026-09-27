using UnityEngine;

public class PuzzleFunctions : MonoBehaviour
{
    public static PuzzleFunctions pf;

    // add any successful print statements, i guess
    public GameObject puzzles;
    public GameObject puzzleBgGlasses;
    public GameObject bomb;
    public GameObject wave;

    protected internal bool alreadySolved;

    private bool open = true;

    void Start(){
        pf = this;
        puzzles.SetActive(false);
        alreadySolved = ButtonFunctions.bf.isPuzzleSolved();
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
    public void microwaveButton(){
        //
    }
    public void addFood(){
        //
    }
}