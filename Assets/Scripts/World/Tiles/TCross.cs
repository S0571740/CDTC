using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCross : Tile
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override char getCharacter()
    {
        if (facing == 0)
        {
            return CharacterTranslator.BOTTOM_LEFT_RIGHT;
        }
        else if (facing == 1)
        {
            return CharacterTranslator.LEFT_TOP_BOTTOM;
        }
        else if (facing == 2)
        {
            return CharacterTranslator.TOP_LEFT_RIGHT;
        }
        return CharacterTranslator.RIGHT_BOTTOM_TOP;
    }

    public override void placeFacing(int facing)
    {
        this.setFacing(facing);
        List<int> exits = new List<int>();
        exits.Add((facing - 1 + 4) % 4);
        exits.Add((facing + 1 + 4) % 4);
        setExits(exits);
    }
}
