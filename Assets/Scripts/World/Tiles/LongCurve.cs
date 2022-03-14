using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongCurve : Tile
{
    private int score = 0;

    public override char getCharacter(){
        return CharacterTranslator.CROSS;
    }

    public override void placeFacing(int facing)
    {
        this.setFacing(facing);
        List<int> exits = new List<int>();
        exits.Add((facing - 1 + 4) % 4);
        setExits(exits);
    }
    
    public override int getScore()
    {
        return this.score;
    }
}
