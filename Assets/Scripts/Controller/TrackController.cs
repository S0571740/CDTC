using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    [SerializeField] private AdvancementController advancementController;
    [SerializeField] private GameManager manager;
    [SerializeField] private int zPos;
    [SerializeField] private int xPos;
    [SerializeField] private Tile lastTile;
    [SerializeField] private Tile[,] track;
    [SerializeField] private GameObject barrier;
    private GameObject barriers;
    private int oldMapSize;

    void Start()
    {
        this.oldMapSize = manager.getMapSize();
        createBarrier();
        zPos = manager.getMapSize() / 2;
        xPos = manager.getMapSize() / 2;
        track = new Tile[oldMapSize, oldMapSize];
        lastTile = advancementController.placeInitialCross();
        track[zPos, xPos] = instantiateTile(lastTile);
    }

    void Update()
    {
        
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

    public void advance(int direction, Tile nextTile)
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
            if (track[zPos, xPos] != null)
            {
                Destroy(track[zPos, xPos].gameObject);
            }
            track[zPos, xPos] = instantiateTile(advancementController.placeNextTile(direction, nextTile));
        }
    }


    private void createBarrier()
    {
        if (barriers != null)
        {
            Destroy(barriers);
        }
        barriers = new GameObject("Barriers");
        for (int i = 0; i < 4; i++)
        {
            GameObject parent = new GameObject("Barriers" + i);
            parent.transform.parent = barriers.transform;
            if (i % 2 == 0)
            {
                int x = manager.getMapSize();
                float rotation = 180;
                int add = 30;
                if (i == 0)
                {
                    x = 0;
                    rotation = 0;
                    add = 0;
                }
                for (int j = 0; j < manager.getMapSize(); j++)
                {
                    GameObject go = Instantiate(barrier, new Vector3(x * 30, 0, j * 30 + add), Quaternion.Euler(0, rotation, 0)).gameObject;
                    go.SetActive(true);
                    go.transform.parent = parent.transform;
                }
            }
            else
            {
                int z = manager.getMapSize();
                float rotation = 90;
                int add = 0;
                if (i == 1)
                {
                    z = 0;
                    rotation = 270;
                    add = 30;
                }
                for (int j = 0; j < manager.getMapSize(); j++)
                {
                    GameObject go = Instantiate(barrier, new Vector3(j * 30 + add, 0, z * 30), Quaternion.Euler(0, rotation, 0)).gameObject;
                    go.SetActive(true);
                    go.transform.parent = parent.transform;
                }
            }
        }
    }

    private Tile instantiateTile(Tile t)
    {
        Quaternion rotation = Quaternion.Euler(0, (t.getFacing() + 1) * 90, 0);
        Vector3 v3Tile = new Vector3(xPos * 30 + 15, 0, zPos * 30 + 15);
        Tile tile = Instantiate(t, v3Tile, rotation);
        tile.gameObject.SetActive(true);
        lastTile = tile;
        manager.prepareNextTile();
        return tile;
    }

    public void restart()
    {
        for (int i = 0; i < oldMapSize; i++)
        {
            for (int j = 0; j < oldMapSize; j++)
            {
                if(track[i, j] != null){
                    Destroy(track[i, j].gameObject);
                }
            }
        }
        track = new Tile[manager.getMapSize(), manager.getMapSize()];
        createBarrier();
        xPos = manager.getMapSize() / 2;
        zPos = manager.getMapSize() / 2;
        lastTile = advancementController.placeInitialCross();
        track[zPos, xPos] = instantiateTile(lastTile);
        this.oldMapSize = manager.getMapSize();
    }
}
