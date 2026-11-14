using UnityEngine;
using UnityEngine.EventSystems;

public class ShowOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objToBeShown;
    
    public void OnPointerEnter(PointerEventData eventData){
        if (!PuzzleFunctions.pf.newImg){
            objToBeShown.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData){
        objToBeShown.SetActive(false);
    }
}