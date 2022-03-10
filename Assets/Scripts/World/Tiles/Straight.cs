using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight : Tile
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override char getCharacter()
    {
        if (facing % 2 == 0)
        {
            return CharacterTranslator.TOP_BOTTOM;
        }
        return CharacterTranslator.LEFT_RIGHT;
    }

    public override void placeFacing(int facing)
    {
        this.setFacing(facing);
        List<int> exits = new List<int>();
        exits.Add(facing);
        setExits(exits);
    }
}