using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancementController : MonoBehaviour
{

    [SerializeField] private List<Tile> tiles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Tile placeNextTile(int facing){
        Tile nextTile = tiles[Random.Range(0, tiles.Count)];
        nextTile.placeFacing(facing);
        return nextTile;
    }

    public Tile placeInitialCross(){
        Tile cross = tiles.Find(tile => tile.name == "Cross");
        cross.placeFacing(0);
        return cross;
    }
}
