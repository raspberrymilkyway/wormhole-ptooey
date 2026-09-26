using UnityEngine;
using UnityEngine.EventSystems;

public class DoorHover : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string direction;
    public string roomToGoTo;
    private bool movingToDoor;

    void Update(){
        if (movingToDoor){
            if (!PlayerMovement.pm.getWalking()){
                movingToDoor = false;
                ButtonFunctions.bf.swapRoom(roomToGoTo);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData){
        ButtonFunctions.bf.changeCursor(direction, false);
    }

    public void OnPointerExit(PointerEventData eventData){
        if (Bookkeeper.bk.getCurrentCursor().Equals("")){
            ButtonFunctions.bf.hideCursor();
        }
        else{
            ButtonFunctions.bf.changeCursor(Bookkeeper.bk.getCurrentCursor());
        }
    }

    public void OnPointerClick(PointerEventData eventData){
        movingToDoor = true;
        Bookkeeper.bk.setDirectionEnteredFrom(direction);
        ClickMovement.cm.OnPointerClick(eventData);
    }
}