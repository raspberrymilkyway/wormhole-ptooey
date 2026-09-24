using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InventoryScene : MonoBehaviour
{
    // handle items scattered around the scene and the inventory ui in a scene

    public List<string> itemPaths = new List<string>{};
    public List<GameObject> itemObjects = new List<GameObject>{};
    public GameObject inventory;

    private int invInd = 0;
    private int xMod = 0;
    private int yPad = 220;

    void Start(){
        for (int i=0; i<itemPaths.Count; i++){
            itemObjects[i].SetActive(Inventory.inv.isItemLoose(itemPaths[i]));
        }
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
        item.name = name;

        Image iimg = item.AddComponent<Image>();
        iimg.sprite = Resources.Load<Sprite>(path);

        Button ibut = item.AddComponent<Button>();
        ibut.onClick.AddListener(() => ButtonFunctions.bf.changeCursor(name));

        RectTransform irt = item.GetComponent<RectTransform>();
        
        irt.SetParent(inventory.transform);
        irt.sizeDelta = new Vector3(150, 150, 0); //resize image
        irt.position = new Vector3(inventory.transform.position.x + xMod, inventory.transform.position.y - yPad - 190*invInd, 0);

        item.SetActive(true);
        // def need to set location, but let's see if this works first
    }
}