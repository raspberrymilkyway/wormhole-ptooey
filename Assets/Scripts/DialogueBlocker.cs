using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueBlocker : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData){
        // continue dialogue or hide
        DialogueHandler.dh.handleDialogue();
    }
}