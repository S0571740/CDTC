using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slalom : Tile
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override char getCharacter(){
        return CharacterTranslator.CROSS;
    }

    public override void placeFacing(int facing)
    {
        this.setFacing(facing);
        List<int> exits = new List<int>();
        exits.Add(facing);
        setExits(exits);
    }
}