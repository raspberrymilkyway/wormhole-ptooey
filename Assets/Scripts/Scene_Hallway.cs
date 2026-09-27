using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Scene_Hallway : MonoBehaviour
{
    public GameObject door4;
    // handle directional movement - fetch from bookkeeper

    void Start(){
        door4.SetActive(Bookkeeper.bk.getHadFlashback());
    }
}