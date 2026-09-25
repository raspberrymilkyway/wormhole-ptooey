using UnityEngine;
using UnityEngine.InputSystem;

public class CursorMovement : MonoBehaviour
{
    void Start(){
        Vector2 screenPos = Pointer.current.position.ReadValue();
        this.transform.position = new Vector3(screenPos.x, screenPos.y, 0);
    }

    void Update(){
        Vector2 screenPos = Pointer.current.position.ReadValue();
        this.transform.position = new Vector3(screenPos.x, screenPos.y, 0);
    }
}