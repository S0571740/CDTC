using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameManager manager;

    [SerializeField] Canvas optionsCanvas;
    [SerializeField] Canvas uiCanvas;
    [SerializeField] Image nextTileImage;
    [SerializeField] Transform speedoMeterNeedle;
    [SerializeField] Text tileText;
    [SerializeField] Text scoreText;
    [SerializeField] private Text mapSizeLabel;
    [SerializeField] private Text speedoMeterText;
    [SerializeField] private Slider mapSizeSlider;
    [SerializeField] private Toggle audioOn;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button startButton;
    [SerializeField] private List<Tile> tileList;
    [SerializeField] private List<Sprite> spriteList;

    private int score = 0;
    private Dictionary<Tile, Sprite> tileSpriteDictionary = new Dictionary<Tile, Sprite>();

    void Start()
    {
        for(int i = 0; i < tileList.Count; i++){
            tileSpriteDictionary.Add(tileList[i], spriteList.Find(sprite => sprite.name.Contains(tileList[i].name)));
        }
        mapSizeLabel.text = mapSizeSlider.value.ToString();
        startButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void updatePreview(Tile nextTile)
    {
        nextTileImage.sprite = tileSpriteDictionary[nextTile];
    }

    public void updateScore(int score)
    {
        this.score = score;
        scoreText.text = this.score.ToString();
    }

    public void restart(Tile nextTile)
    {
        updateScore(this.score * -1);
        updatePreview(nextTile);
    }

    public void updateNumber()
    {
        mapSizeLabel.text = mapSizeSlider.value.ToString();
    }

    public void startGame()
    {
        startButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        manager.startNewGame(audioOn.isOn, (int)mapSizeSlider.value);
    }

    public void toggleUI(bool active)
    {
        uiCanvas.gameObject.SetActive(active);
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
}
