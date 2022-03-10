using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private int mapSize = 3;
    [SerializeField] AdvancementController advancementController;
    [SerializeField] PlayerController playerController;
    [SerializeField] TrackController trackController;
    [SerializeField] bool debug = false;

    void Start(){
        if(debug){
            playerController.setDebug();
        }
    }
    // Start is called before the first frame update
    public int getMapSize()
    {
        return mapSize;
    }
}
