using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Image nextTileImage;
    [SerializeField] Text text;
    void Start()
    {

    }

    void Update()
    {

    }

    public void updatePreview(Tile nextTile)
    {
        text.text = nextTile.getCharacter().ToString();
        // Texture2D t2d = AssetPreview.GetAssetPreview(nextTile.gameObject);
        // nextTileImage.sprite = Sprite.Create(t2d, new Rect(0, 0, t2d.width, t2d.height), new Vector2(0, 0));
    }
}