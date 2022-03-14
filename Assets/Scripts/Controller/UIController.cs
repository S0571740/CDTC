using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Image nextTileImage;
    [SerializeField] Text tileText;
    [SerializeField] Text scoreText;

    private int score = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    public void updatePreview(Tile nextTile)
    {
        tileText.text = nextTile.getCharacter().ToString();
        // Texture2D t2d = AssetPreview.GetAssetPreview(nextTile.gameObject);
        // nextTileImage.sprite = Sprite.Create(t2d, new Rect(0, 0, t2d.width, t2d.height), new Vector2(0, 0));
    }

    public void updateScore(int score){
        this.score += score;
        scoreText.text = this.score.ToString();
    }

    public void restart(Tile nextTile){
        updateScore(this.score * -1);
        updatePreview(nextTile);
    }
}