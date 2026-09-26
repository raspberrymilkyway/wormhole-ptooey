using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ClickMovement : MonoBehaviour, IPointerClickHandler
{
    public GameObject player;
    public int maxStandingX = 1600; //not 1920 because of inventory + centered player sprite
    public int minStandingX = 0;
    public int maxStandingY = 1080;
    public int minStandingY = 0;

    private Camera cam;

    void Start(){
        cam = Bookkeeper.bk.getCamera();
    }

    public void OnPointerClick(PointerEventData eventData){
        Vector2 endPoint = Pointer.current.position.ReadValue();
        if (endPoint.x > maxStandingX){
            endPoint.x = maxStandingX;
        }
        if (endPoint.x < minStandingX){
            endPoint.x = minStandingX;
        }
        if (endPoint.y > maxStandingY){
            endPoint.y = maxStandingY;
        }
        if (endPoint.y < minStandingY){
            endPoint.y = minStandingY;
        }
        PlayerMovement.pm.walk(new Vector3(endPoint.x, endPoint.y, 0));
    }
}
