using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableClick : MonoBehaviour, IPointerClickHandler
{
    public bool inventoryItem = false;
    public bool puzzleOpener = false;
    public string inventoryItemPath = "";
    public bool isSpoken;
    public bool isCharacter;
    private bool movingToClickable;
    private string blurb;

    void Start(){
        if (isCharacter){
            blurb = Descriptions.desc.chars[this.gameObject.name];
        }
        else{
            blurb = Descriptions.desc.items[this.gameObject.name];
        }
    }

    void Update(){
        if (movingToClickable){
            if (!PlayerMovement.pm.getWalking()){
                movingToClickable = false;
                ButtonFunctions.bf.blurb(blurb, isSpoken);
                if (inventoryItem){
                    Inventory.inv.looseToCurrItem(inventoryItemPath);
                    this.gameObject.SetActive(false);
                }
                else if (puzzleOpener){
                    PuzzleFunctions.pf.showPuzzleWindow();
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData){
        movingToClickable = true;
        ClickMovement.cm.OnPointerClick(eventData);
    }
}