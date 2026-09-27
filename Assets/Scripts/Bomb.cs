using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Bomb : MonoBehaviour, IPointerClickHandler
{
    public static Bomb bomb;

    void Start(){
        bomb = this;

        if (Bookkeeper.bk.getBombStatus().Item2){
            this.enabled = false;
        }
    }
    
    public void OnPointerClick(PointerEventData eventData){
        Bookkeeper.bk.addPoints(5, 1000); // b o m b e n d i n g
        // unless you defuse!
    }

    public void defuse(){
        Bookkeeper.bk.addPoints(5, -1000); // defused!
        Bookkeeper.bk.defuseBomb();
        ((ClickableClick)this.gameObject.GetComponent("ClickableClick")).enabled = false;
        PuzzleFunctions.pf.hidePuzzleWindow();
        DialogueHandler.dh.showDialogueBox(new List<string>{"You've successfully defused the bomb! Whew."});
    }
    
    public void detonate(){
        Bookkeeper.bk.detonateBomb();
        ButtonFunctions.bf.swapRoom("End"); //game over
    }
}