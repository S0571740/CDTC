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
    [SerializeField] GameObject playerGreen;
    [SerializeField] GameObject playerRed;
    [SerializeField] GameObject playerBlue;

    private int score = 0;
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

    void FixedUpdate()
    {
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
        updateScore(-(this.score));
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
        updateScore(nextTile.getScore());
        trackController.advance(direction, nextTile);
    }

    public Tile getNextTile()
    {
        return this.nextTile;
    }

    public void startNewGame(bool audioOn, int mapSize, int playerSelected)
    {
        updateScore(-(this.score));
        pause = false;
        this.mapSize = mapSize;
        audioController.switchTrack();
        if (audioOn)
        {
            audioController.enable();
        }
        else{
            audioController.disable();
        }
        switch (playerSelected)
        {
            case -1:
                playerController.setPlayer(playerBlue);
                break;
            case 0:
                playerController.setPlayer(playerRed);
                break;
            case 1:
                playerController.setPlayer(playerGreen);
                break;
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

    public bool getDebug()
    {
        return debug;
    }

    public void updateScore(int score)
    {
        this.score += score;
        uiController.updateScore(this.score);
        playerController.addSpeed(this.score);
    }

    public void gameOver(){
        uiController.setGameOverHighscoreText(this.score);
        Time.timeScale = 0f;
        uiController.toggleGameOver(true);
        uiController.toggleUI(false);
    }

}
