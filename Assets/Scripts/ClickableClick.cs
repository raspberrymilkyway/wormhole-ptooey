using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableClick : MonoBehaviour, IPointerClickHandler
{
    public string blurb = "";
    public bool inventoryItem = false;
    public bool puzzleOpener = false;
    public string inventoryItemPath = "";
    private bool movingToClickable;

    void Update(){
        if (movingToClickable){
            if (!PlayerMovement.pm.getWalking()){
                movingToClickable = false;
                ButtonFunctions.bf.blurb(blurb);
                if (inventoryItem){
                    Inventory.inv.looseToCurrItem(inventoryItemPath);
                    this.gameObject.SetActive(false);
                }
                else if (puzzleOpener){
                    // open puzzle, but also check if it's solved
                    Debug.Log("puzzle window should open");
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData){
        movingToClickable = true;
        ClickMovement.cm.OnPointerClick(eventData);
    }
}