using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableClick : MonoBehaviour, IPointerClickHandler
{
    public string blurb = "";
    public bool inventoryItem = false;
    private bool movingToClickable;

    void Update(){
        if (movingToClickable){
            if (!PlayerMovement.pm.getWalking()){
                movingToClickable = false;
                ButtonFunctions.bf.blurb(blurb);
                if (inventoryItem){
                    Inventory.inv.looseToCurrItem("inventory/" + this.GetComponent<Image>().sprite.name);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData){
        movingToClickable = true;
        ClickMovement.cm.OnPointerClick(eventData);
    }
}