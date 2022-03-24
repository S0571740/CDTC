using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCross : Tile
{
    private int score = 20;
    [SerializeField] private GameObject randomObject;

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

    public override int getScore()
    {
        return this.score;
    }

    public override void placeRandom(int facing)
    {
        if (Random.Range(0, 100) > 80)
        {
            int rotation = facing;
            Vector3 v3 = randomObject.transform.position;
            GameObject random = ObstacleController.getRandomObject();
            if (random.name.Equals("WreckingBall"))
            {
                v3.y += 6f;
            }
            else
            {
                v3.y += 0.5f;
            }
            randomObject = Instantiate(random, v3, Quaternion.Euler(0, rotation * 90, 0));
            randomObject.SetActive(true);
        }
    }

    public override GameObject getRandomObject(){
        return randomObject;
    }
}
