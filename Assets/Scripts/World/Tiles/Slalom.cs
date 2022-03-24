using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slalom : Tile
{
    private int score = 40;
    [SerializeField] private GameObject randomObject;

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

    public override int getScore()
    {
        return this.score;
    }

    public override void placeRandom(int facing)
    {
        if (Random.Range(0, 100) > 80)
        {
            int rotation = facing + 1;
            Vector3 v3 = randomObject.transform.position;
            GameObject random = ObstacleController.getRandomObject();
            if(random.name.Equals("WreckingBall")){
                v3.y += 6f;
            }
            else{
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
