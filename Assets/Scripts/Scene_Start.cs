using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scene_Start : MonoBehaviour
{
    public static Scene_Start sc_st;

    public GameObject endings;
    public GameObject credits;
    public TMP_Text[] endingText = new TMP_Text[6];
    public Image[] endingImg = new Image[6];

    void Start(){
        sc_st = this;

        disableCredits();
        disableEndings();

        bool[] ends = Bookkeeper.bk.getEndings();
        for (int i=0; i<ends.Length; i++){
            if (!ends[i]){
                endingText[i].text = "???";
                endingImg[i].sprite = Resources.Load<Sprite>("junk/questionMark");
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
}
