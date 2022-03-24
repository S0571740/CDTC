using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancementController : MonoBehaviour
{

    [SerializeField] private List<Tile> tiles;
    [SerializeField] private Tile debugTile;
    [SerializeField] private Cross cross;

    public Tile placeNextTile(int facing, Tile nextTile){
        nextTile.placeFacing(facing);
        return nextTile;
    }

    public Tile placeInitialCross(){
        cross.placeFacing(0);
        return cross;
    }

    public Tile getNextTile(){
        Tile nextTile = tiles[Random.Range(0, tiles.Count)];
        // Tile nextTile = debugTile;
        nextTile.placeFacing(0);
        return nextTile;
    }
}
