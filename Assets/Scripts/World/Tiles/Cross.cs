using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : Tile
{
    private int score = 10;

    public override char getCharacter()
    {
        return CharacterTranslator.CROSS;
    }

    public override void placeFacing(int facing)
    {
        this.setFacing(facing);
        List<int> exits = new List<int>();
        exits.Add((facing - 1 + 4) % 4);
        exits.Add((facing + 0 + 4) % 4);
        exits.Add((facing + 1 + 4) % 4);
        setExits(exits);
    }
    
    public override int getScore()
    {
        return this.score;
    }
}
