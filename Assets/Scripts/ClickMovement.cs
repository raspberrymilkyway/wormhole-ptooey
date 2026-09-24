using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ClickMovement : MonoBehaviour, IPointerClickHandler
{
    public GameObject player;

    private Camera cam;

    void Start(){
        cam = Bookkeeper.bk.getCamera();
    }

    public void OnPointerClick(PointerEventData eventData){
        Vector2 screenPos = Pointer.current.position.ReadValue();
        player.GetComponent<RectTransform>().position = new Vector3(screenPos.x, screenPos.y, 0);
    }
}
