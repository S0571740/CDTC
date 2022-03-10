using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private int mapSize = 51;
    [SerializeField] AdvancementController advancementController;
    [SerializeField] PlayerController playerController;
    [SerializeField] TrackController trackController;
    [SerializeField] UIController uiController;
    [SerializeField] bool debug = false;
    private Tile nextTile;

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

    public void restart(){
        playerController.restart();
        trackController.restart();
    }

    public void prepareNextTile(){
        nextTile = advancementController.getNextTile();
        uiController.updatePreview(nextTile);
    }

    public void advance(int direction){
        Debug.Log(direction);
        trackController.advance(direction, nextTile);
    }

    public Tile getNextTile(){
        return this.nextTile;
    }
}
