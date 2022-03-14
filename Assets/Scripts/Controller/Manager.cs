using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private int mapSize = 11;
    [SerializeField] AdvancementController advancementController;
    [SerializeField] PlayerController playerController;
    [SerializeField] TrackController trackController;
    [SerializeField] UIController uiController;
    [SerializeField] GameObject audioController;
    [SerializeField] bool debug = false;
    [SerializeField] bool audioOnOff = false;
    private Tile nextTile;

    void Start(){
        if(debug){
            playerController.setDebug();
        }
        if(!audioOnOff){
            audioController.GetComponent<AudioSource>().Stop();
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
        uiController.restart(nextTile);
    }

    public void prepareNextTile(){
        nextTile = advancementController.getNextTile();
        uiController.updatePreview(nextTile);
    }

    public void advance(int direction){
        int score = nextTile.getScore();
        uiController.updateScore(score);
        playerController.addSpeed(score);
        trackController.advance(direction, nextTile);
    }

    public Tile getNextTile(){
        return this.nextTile;
    }
}
