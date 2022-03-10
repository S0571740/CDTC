using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    [SerializeField] private AdvancementController advancementController;
    [SerializeField] private Manager manager;
    [SerializeField] private int zPos;
    [SerializeField] private int xPos;
    [SerializeField] private Tile lastTile;
    [SerializeField] private Tile[,] realTrack;
    [SerializeField] private GameObject barrier;

    void Start()
    {
        createBarrier();
        zPos = manager.getMapSize() / 2;
        xPos = manager.getMapSize() / 2;
        realTrack = new Tile[manager.getMapSize(), manager.getMapSize()];
        lastTile = advancementController.placeInitialCross();
        realTrack[zPos, xPos] = lastTile;
        instantiateAndActivate(realTrack[zPos, xPos]);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log(realTrack[zPos, xPos]);
            // printTrack();
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            advance(0);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            advance(1);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            advance(2);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            advance(3);
        }
    }

    // private void printTrack()
    // {
    //     for (int i = 0; i < maxSize; i++)
    //     {
    //         string line = "";
    //         for (int j = 0; j < maxSize; j++)
    //         {
    //             line = line + track[i, j];
    //         }
    //         Debug.Log(line);
    //     }
    //     string finalLine = "";
    //     for (int i = 0; i < maxSize; i++)
    //     {
    //         finalLine = finalLine + "-";
    //     }
    //     Debug.Log(finalLine);
    // }

    public void advance(int direction)
    {
        bool next = false;
        if (direction % 2 == 0)
        {
            if (lastTile.getExits().Contains(direction))
            {
                if (direction > 1 && zPos < manager.getMapSize() - 1)
                {
                    zPos++;
                    next = true;
                }
                else if (direction < 2 && zPos > 0)
                {
                    zPos--;
                    next = true;
                }
            }
        }
        else
        {
            if (lastTile.getExits().Contains(direction))
            {
                if (direction > 1 && xPos < manager.getMapSize() - 1)
                {
                    xPos++;
                    next = true;
                }
                else if (direction < 2 && xPos > 0)
                {
                    xPos--;
                    next = true;
                }
            }
        }
        if (next)
        {
            if (realTrack[zPos, xPos] != null)
            {
                realTrack[zPos, xPos].transform.gameObject.SetActive(false);
            }
            Tile nextTile = advancementController.placeNextTile(direction);
            if ((direction == 0 && zPos == 0) ||
                (direction == 1 && xPos == 0) ||
                (direction == 2 && zPos == manager.getMapSize() - 1) ||
                (direction == 3 && xPos == manager.getMapSize() - 1)
                )
            {
                while (!nextTile.getExits().Exists(exit => exit != direction))
                {
                    nextTile = advancementController.placeNextTile(direction);
                }
            }
            lastTile = nextTile;
            instantiateAndActivate(lastTile);
        }
    }

    private void instantiateAndActivate(Tile tile)
    {
        tile.transform.gameObject.SetActive(true);
        Quaternion rotation = Quaternion.Euler(0, (tile.getFacing() + 1) * 90, 0);
        realTrack[zPos, xPos] = Instantiate(tile, new Vector3(xPos * 30 + 15, 0, zPos * 30 + 15), rotation);
    }

    private void createBarrier()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i % 2 == 0)
            {
                int x = manager.getMapSize();
                float rotation = 180;
                int add = 30;
                if(i == 0){
                    x = 0;
                    rotation = 0;
                    add = 0;
                }
                for (int j = 0; j < manager.getMapSize(); j++)
                {
                    Instantiate(barrier, new Vector3(x * 30, 0, j * 30 + add), Quaternion.Euler(0, rotation, 0)).gameObject.SetActive(true);
                }
            }
            else
            {
                int z = manager.getMapSize();
                float rotation = 90;
                int add = 0;
                if(i == 1){
                    z = 0;
                    rotation = 270;
                    add = 30;
                }
                for (int j = 0; j < manager.getMapSize(); j++)
                {
                    Instantiate(barrier, new Vector3(j * 30 + add, 0, z * 30), Quaternion.Euler(0, rotation, 0)).gameObject.SetActive(true);
                }
            }
        }
    }
}
