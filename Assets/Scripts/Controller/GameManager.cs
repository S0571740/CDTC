using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int mapSize = 11;
    [SerializeField] AdvancementController advancementController;
    [SerializeField] PlayerController playerController;
    [SerializeField] TrackController trackController;
    [SerializeField] UIController uiController;
    [SerializeField] AudioController audioController;
    [SerializeField] bool debug = false;
    [SerializeField] bool audioOn = false;
    [SerializeField] bool pause = false;
    [SerializeField] bool initialized = false;

    private Tile nextTile;

    void Start()
    {
        Time.timeScale = 0f;
        uiController.toggleOptions(true);
        uiController.toggleUI(false);
        if (debug)
        {
            playerController.setDebug();
        }
    }

    void FixedUpdate(){
        uiController.setSpeedoMeterText(playerController.getAcceleration());
    }

    private void init()
    {
        initialized = true;
        Time.timeScale = 1f;
        uiController.toggleOptions(false);
        uiController.toggleUI(true);
        playerController.restart();
        trackController.restart();
        uiController.restart(nextTile);
    }

    // Start is called before the first frame update
    public int getMapSize()
    {
        return mapSize;
    }

    public void restart()
    {
        playerController.restart();
        trackController.restart();
        uiController.restart(nextTile);
    }

    public void prepareNextTile()
    {
        nextTile = advancementController.getNextTile();
        uiController.updatePreview(nextTile);
    }

    public void advance(int direction)
    {
        int score = nextTile.getScore();
        uiController.updateScore(score);
        playerController.addSpeed(score);
        trackController.advance(direction, nextTile);
    }

    public Tile getNextTile()
    {
        return this.nextTile;
    }

    public void startNewGame(bool audioOn, int mapSize)
    {
        pause = false;
        this.mapSize = mapSize;
        if (audioOn)
        {
            audioController.GetComponent<AudioSource>().Play();
        }
        init();
    }

    public void pauseGame()
    {
        if (initialized)
        {

            if (pause)
            {
                Time.timeScale = 1f;
                uiController.toggleOptions(!pause);
                uiController.toggleUI(pause);
            }
            else
            {
                Time.timeScale = 0f;
                uiController.toggleOptions(!pause);
                uiController.toggleUI(pause);
            }
            pause = !pause;
        }
    }

    public bool getDebug(){
        return debug;
    }
}
