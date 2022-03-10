using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortLeftCurve : Tile
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override char getCharacter(){
        if (facing == 0)
        {
            return CharacterTranslator.LEFT_BOTTOM;
        }
        else if (facing == 1)
        {
            return CharacterTranslator.TOP_LEFT;
        }
        else if (facing == 2)
        {
            return CharacterTranslator.RIGHT_TOP;
        }
        return CharacterTranslator.BOTTOM_RIGHT;
    }

    public override void placeFacing(int facing)
    {
        this.setFacing(facing);
        List<int> exits = new List<int>();
        exits.Add((facing - 1 + 4) % 4);
        setExits(exits);
    }
}
