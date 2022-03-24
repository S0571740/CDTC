using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private Player player;
    [SerializeField] private GameObject defaultPlayer;
    [SerializeField] private TrackController trackController;
    [SerializeField] private Camera cam;
    private bool flag = false;
    private int tileSize = 30;
    private int activationRange = 5;
    private GameObject playerGameObject;

    public float checkZ;
    public float checkX;


    void Start()
    {
        if(player == null){
            player = defaultPlayer.GetComponent<Player>();
        }
        player.transform.SetPositionAndRotation(
            new Vector3((manager.getMapSize() / 2) * tileSize + 15, 0, (manager.getMapSize() / 2) * tileSize + 15),
            Quaternion.Euler(0, -90, 0));
    }

    public void setDebug()
    {
        player.GetComponent<Rigidbody>().useGravity = false;
        player.transform.SetPositionAndRotation(
            new Vector3((manager.getMapSize() / 2) * tileSize + 15, 100, (manager.getMapSize() / 2) * tileSize + 15),
            Quaternion.Euler(0, 180, 0));
    }

    void Update()
    {
        if(player.transform.localPosition.y < - 2){
            manager.gameOver();
        }
        checkZ = Mathf.Abs(player.transform.localPosition.z) % tileSize;
        checkX = Mathf.Abs(player.transform.localPosition.x) % tileSize;
        if (flag)
        {
            if (checkZ <= activationRange)
            {
                flag = false;
                manager.advance(0);
            }
            else if (checkX <= activationRange)
            {
                flag = false;
                manager.advance(1);
            }
            else if (checkZ >= tileSize - activationRange)
            {
                flag = false;
                manager.advance(2);
            }
            else if (checkX >= tileSize - activationRange)
            {
                flag = false;
                manager.advance(3);
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
        flag = true;
        Vector3 posPlayer = new Vector3((manager.getMapSize() / 2) * tileSize + 15, 0.5f, (manager.getMapSize() / 2) * tileSize + 15);
        player.restart();
        player.transform.SetPositionAndRotation(posPlayer, Quaternion.Euler(0, -90, 0));
    }

    public void addSpeed(int speed){
        player.updateMinSpeed(speed / 100f);
    }

    public float getAcceleration(){
        return player.getAcceleration();
    }

    public void addScore(int score){
        manager.updateScore(score);
    }

    public void setPlayer(GameObject player){
        Vector3 pos = new Vector3((manager.getMapSize() / 2) * tileSize + 15, 5, (manager.getMapSize() / 2) * tileSize + 15);
        cam.transform.parent = this.transform;
        if(this.player.gameObject != null){
            Destroy(this.player.gameObject);
        }
        playerGameObject = Instantiate(player, pos, Quaternion.Euler(0, -90, 0));
        this.player = playerGameObject.GetComponent<Player>();
        this.player.transform.parent = this.transform;
        cam.transform.parent = this.player.transform;
        cam.transform.localPosition = new Vector3(0, 2, -3);
        cam.transform.rotation = Quaternion.Euler(15, -90, 0);
    }
}
