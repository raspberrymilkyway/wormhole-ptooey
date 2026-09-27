using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scene_Start : MonoBehaviour
{
    public static Scene_Start sc_st;

    public GameObject endings;
    public GameObject credits;
    public GameObject start;
    public Button cont;
    public TMP_Text[] endingText = new TMP_Text[6];
    public Image[] endingImg = new Image[6];

    void Start(){
        sc_st = this;

        disableCredits();
        disableEndings();
        disableStartPop();

        if (!SaveData.sd.wasDataLoaded()){
            cont.interactable = false;
            cont.GetComponentsInChildren<TMP_Text>()[0].color = new Color(0.5f, 0.5f, 0.5f, 1);
        }

        bool[] ends = Bookkeeper.bk.getEndings();
        for (int i=0; i<ends.Length; i++){
            if (!ends[i]){
                endingText[i].text = "???";
                endingImg[i].sprite = Resources.Load<Sprite>("q");
            }
        }
    }

    protected internal void enableCredits(){
        credits.SetActive(true);
    }
    protected internal void disableCredits(){
        credits.SetActive(false);
    }
    protected internal void enableEndings(){
        endings.SetActive(true);
    }
    protected internal void disableEndings(){
        endings.SetActive(false);
    }
    protected internal void enableStartPop(){
        start.SetActive(true);
    }
    protected internal void disableStartPop(){
        start.SetActive(false);
    }
}
