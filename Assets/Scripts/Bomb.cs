using UnityEngine;
using UnityEngine.EventSystems;

public class Bomb : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData){
        Bookkeeper.bk.addPoints(5, 1000); // b o m b e n d i n g
        // unless you defuse!
    }
}