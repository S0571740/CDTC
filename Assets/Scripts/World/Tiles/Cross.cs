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
        switch (facing)
        {
            case 0:
                this.setFacing(0);
                break;
            case 1:
                this.setFacing(3);
                break;
            case 2:
                this.setFacing(2);
                break;
            case 3:
                this.setFacing(1);
                break;
        }
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

    public override void placeRandom(int facing){}
    public override GameObject getRandomObject(){
        return null;
    }

}
