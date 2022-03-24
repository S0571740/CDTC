using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public List<int> exits = new List<int>();
    protected int facing;

    public List<int> getExits()
    {
        return exits;
    }

    protected void setExits(List<int> exits)
    {
        this.exits = exits;
    }

    public abstract char getCharacter();


    /// <summary>
    ///
    /// </summary>
    /// <param name="facing">Direction the tile is facing. 0 = North, 1 = East, 2 = South, 3 = West</param>
    public abstract void placeFacing(int facing);

    public abstract void placeRandom(int facing);
    public abstract GameObject getRandomObject();
    
    protected void setFacing(int facing)
    {
        this.facing = facing;
    }

    public int getFacing()
    {
        return facing;
    }

    public abstract int getScore();
}
