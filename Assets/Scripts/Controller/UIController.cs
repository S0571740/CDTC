using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameManager manager;

    [SerializeField] private Canvas optionsCanvas;
    [SerializeField] private Canvas uiCanvas;
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Image nextTileImage;
    [SerializeField] private Transform speedoMeterNeedle;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text gameOverScoreText;
    [SerializeField] private Text mapSizeLabel;
    [SerializeField] private Text mapSizeLabel2;
    [SerializeField] private Text speedoMeterText;
    [SerializeField] private Slider mapSizeSlider;
    [SerializeField] private Slider mapSizeSlider2;
    [SerializeField] private Toggle audioOn;
    [SerializeField] private Toggle audioOn2;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button startButton;
    [SerializeField] private List<Tile> tileList;
    [SerializeField] private List<Sprite> spriteList;
    [SerializeField] private Image selection;
    [SerializeField] private Image selection2;

    private int selectedPlayer = 0;
    private int score = 0;
    private Dictionary<Tile, Sprite> tileSpriteDictionary = new Dictionary<Tile, Sprite>();

    void Start()
    {
        mapSizeLabel.text = mapSizeSlider.value.ToString();
        startButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    private void initMap(){
        for(int i = 0; i < tileList.Count; i++){
            tileSpriteDictionary.Add(tileList[i], spriteList.Find(sprite => sprite.name.Contains(tileList[i].name)));
        }
    }

    public void updatePreview(Tile nextTile)
    {
        if(tileSpriteDictionary.Count == 0){
            initMap();
        }
        nextTileImage.sprite = tileSpriteDictionary[nextTile];
    }

    public void updateScore(int score)
    {
        this.score = score;
        scoreText.text = this.score.ToString();
    }

    public void restart(Tile nextTile)
    {
        toggleUI(true);
        toggleGameOver(false);
        toggleOptions(false);
        updatePreview(nextTile);
    }

    public void updateNumber()
    {
        mapSizeLabel.text = mapSizeSlider.value.ToString();
        mapSizeLabel2.text = mapSizeSlider2.value.ToString();
    }

    public void startGame(string gameoverOrEscape)
    {
        startButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        if(gameoverOrEscape.Equals("gameover")){
            manager.startNewGame(audioOn2.isOn, (int)mapSizeSlider2.value, selectedPlayer);
        }
        else{
            manager.startNewGame(audioOn.isOn, (int)mapSizeSlider.value, selectedPlayer);
        }
    }

    public void setAudioOn(){
        audioOn.isOn = audioOn2.isOn;
    }

    public void toggleUI(bool active)
    {
        uiCanvas.gameObject.SetActive(active);
    }

    public void toggleGameOver(bool active)
    {
        gameOverCanvas.gameObject.SetActive(active);
    }

    public void toggleOptions(bool active)
    {
        optionsCanvas.gameObject.SetActive(active);
    }

    public void pauseGame()
    {
        manager.pauseGame();
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void setSpeedoMeterText(float speed)
    {
        speedoMeterText.text = ((int)(speed / 3 * 10)).ToString();
        speedoMeterNeedle.rotation = Quaternion.Euler(0, 0, 90 - speed / 3 * 10);
    }

    public void setPlayer(int player){
        selectedPlayer = player;
        Vector3 pos = new Vector3(player * 100, selection.transform.localPosition.y, selection.transform.localPosition.z);
        Vector3 pos2 = new Vector3(player * 100, selection2.transform.localPosition.y, selection2.transform.localPosition.z);
        selection.transform.localPosition = pos;
        selection2.transform.localPosition = pos2;
    }

    public void setGameOverHighscoreText(int highscore){
        gameOverScoreText.text = highscore.ToString();
    }
}
