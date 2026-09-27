using UnityEngine;
using UnityEngine.EventSystems;

public class DoorHover : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string direction;
    public string roomToGoTo;
    private bool movingToDoor;
    private bool canGoIn = true;

    void Start(){
        if (roomToGoTo.Equals("Cabin") && !Bookkeeper.bk.getCabinState()){
            direction = "x";
            canGoIn = false;
        }
    }

    void Update(){
        if (movingToDoor){
            if (!PlayerMovement.pm.getWalking()){
                movingToDoor = false;
                if (Bookkeeper.bk.checkWin()){
                    ButtonFunctions.bf.swapRoom("End");
                }
                else{
                    ButtonFunctions.bf.swapRoom(roomToGoTo);
                }
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
        if (canGoIn){
            movingToDoor = true;
            Bookkeeper.bk.setDirectionEnteredFrom(direction);
            ClickMovement.cm.OnPointerClick(eventData);
        }
        // else thought bubble "i'm not going back in there."
    }
}