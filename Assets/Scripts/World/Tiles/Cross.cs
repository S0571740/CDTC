using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : Tile
{
    // Start is called before the first frame update
    void Start()
    {

    }

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
}
