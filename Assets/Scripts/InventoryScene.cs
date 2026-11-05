using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InventoryScene : MonoBehaviour
{
    // handle items scattered around the scene and the inventory ui in a scene
    public static InventoryScene isc;

    public List<string> itemPaths = new List<string>{};
    public List<GameObject> itemObjects = new List<GameObject>{};
    public GameObject inventory;
    public Image cursor;

    private int invInd = 0;
    private int xMod = 0;
    private int yPad = 190;

    void Start(){
        isc = this;
        for (int i=0; i<itemPaths.Count; i++){
            bool show = Inventory.inv.isItemLoose(itemPaths[i]);
            bool keepBase = Inventory.inv.shouldBaseStay(itemPaths[i]);
            if (!show && keepBase){
                show = true;
                ((ClickableClick)itemObjects[i].GetComponent("ClickableClick")).inventoryItem = false;
            }
            itemObjects[i].SetActive(show);
        }
        cursor.gameObject.SetActive(false);
        setInventory();
    }

    protected internal void obtainItem(string path){
        itemObjects[itemPaths.IndexOf(path)].SetActive(false);
        Inventory.inv.looseToCurrItem(path);
    }

    protected internal void setInventory(){
        List<string> curr = Inventory.inv.getCurrItems();
        for (int i=0; i<curr.Count; i++){
            string name = curr[i].Split("/", 2)[1];
            addItemToDisplay(curr[i], name);
            invInd++;
            if (invInd / 5.0 >= 1){
                invInd = 0;
                xMod += 245; //shift rightward. extend inventory bar. scooch it leftwards on arrow click. assuming we even get an inventory that big??
                // just gonna set up item placement right now, i suppose
            }
        }
    }

    protected internal void addItemToDisplay(string path, string name){
        GameObject item = new GameObject();
        GameObject itemBg = new GameObject();
        item.name = name;
        itemBg.name = name + "Bg";

        Image iimg = item.AddComponent<Image>();
        Image bimg = itemBg.AddComponent<Image>();
        iimg.sprite = Resources.Load<Sprite>(path);
        bimg.sprite = Resources.Load<Sprite>("inventory/inventory-square");

        Button ibut = item.AddComponent<Button>();
        ibut.onClick.AddListener(() => ButtonFunctions.bf.changeCursor(name));

        RectTransform irt = item.GetComponent<RectTransform>();
        RectTransform brt = itemBg.GetComponent<RectTransform>();
        brt.SetParent(inventory.transform); //lower in hierarchy
        irt.SetParent(inventory.transform);
        irt.sizeDelta = new Vector3(150, 150, 0); //resize image
        brt.sizeDelta = new Vector3(175, 175, 0);
        irt.position = new Vector3(inventory.transform.position.x + xMod, inventory.transform.position.y - yPad - 190*invInd, 0);
        brt.position = new Vector3(inventory.transform.position.x + xMod, inventory.transform.position.y - yPad - 190*invInd, 0);

        item.SetActive(true);
        itemBg.SetActive(true);
    }
}