using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Manager manager;
    [SerializeField] Player player;
    [SerializeField] Camera camera;
    [SerializeField] TrackController trackController;
    private bool flag = true;
    private int tileSize = 30;
    private int activationRange = 5;

    public float checkZ;
    public float checkX;


    void Start()
    {
        player.transform.SetPositionAndRotation(
        new Vector3((manager.getMapSize() / 2) * tileSize + 15, 0, (manager.getMapSize() / 2) * tileSize + 15),
        Quaternion.Euler(0, 180, 0));
    }

    public void setDebug()
    {
        player.GetComponent<Rigidbody>().useGravity = false;
        player.transform.SetPositionAndRotation(
            new Vector3((manager.getMapSize() / 2) * tileSize + 15, 100, (manager.getMapSize() / 2) * tileSize + 15),
            Quaternion.Euler(0, 180, 0));
        camera.transform.SetPositionAndRotation(
            new Vector3((manager.getMapSize() / 2) * tileSize + 15, 100, (manager.getMapSize() / 2) * tileSize + 15),
            Quaternion.Euler(90, 180, 0));
    }

    void Update()
    {
        if(this.transform.localPosition.y < - 2){
            manager.restart();
        }
        checkZ = this.transform.localPosition.z % tileSize;
        checkX = this.transform.localPosition.x % tileSize;
        if (flag)
        {
            if (checkZ <= activationRange)
            {
                flag = false;
                trackController.advance(0);
            }
            else if (checkX <= activationRange)
            {
                flag = false;
                trackController.advance(1);
            }
            else if (checkZ >= tileSize - activationRange)
            {
                flag = false;
                trackController.advance(2);
            }
            else if (checkX >= tileSize - activationRange)
            {
                flag = false;
                trackController.advance(3);
            }
        }
        else
        {
            if (checkZ < tileSize - activationRange && checkZ > activationRange && checkX < tileSize - activationRange && checkX > activationRange)
            {
                flag = true;
            }
        }
    }

    public void restart()
    {
        player.restart();
        player.transform.SetPositionAndRotation(
        new Vector3((manager.getMapSize() / 2) * tileSize + 15, 0, (manager.getMapSize() / 2) * tileSize + 15),
        Quaternion.Euler(0, 180, 0));
    }
}
