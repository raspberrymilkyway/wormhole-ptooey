using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string finger;

    public void OnPointerEnter(PointerEventData eventData){
        ButtonFunctions.bf.changeCursor(finger, false);
    }

    public void OnPointerExit(PointerEventData eventData){
        if (Bookkeeper.bk.getCurrentCursor().Equals("")){
            ButtonFunctions.bf.hideCursor();
        }
        else{
            ButtonFunctions.bf.changeCursor(Bookkeeper.bk.getCurrentCursor());
        }
    }
}