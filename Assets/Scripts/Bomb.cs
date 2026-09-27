using UnityEngine;
using UnityEngine.EventSystems;

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
    }
    
    public void detonate(){
        Bookkeeper.bk.detonateBomb();
        ButtonFunctions.bf.swapRoom("End"); //game over
    }
}