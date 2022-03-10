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

    public void setDebug(){
        player.GetComponent<Rigidbody>().useGravity = false;
        player.transform.SetPositionAndRotation(
            new Vector3((manager.getMapSize() / 2) * tileSize + 15, 100, (manager.getMapSize() / 2) * tileSize + 15),
            Quaternion.Euler(0, 180, 0));
        camera.transform.SetPositionAndRotation(
            new Vector3((manager.getMapSize() / 2) * tileSize + 15, 100, (manager.getMapSize() / 2) * tileSize + 15),
            Quaternion.Euler(90, 180, 0));
    }

    void Update(){
        // Debug.Log(this.transform.localPosition.z);
        checkZ = this.transform.localPosition.z % tileSize;
        checkX = this.transform.localPosition.x % tileSize;
        if(flag){
            if(checkZ <= activationRange){
                flag = false;
                trackController.advance(0);
                Debug.Log("FALSE");
            }
            else if(checkX <= activationRange){
                flag = false;
                trackController.advance(1);
                Debug.Log("FALSE");
            }
            else if(checkZ >= tileSize - activationRange){
                flag = false;
                trackController.advance(2);
                Debug.Log("FALSE");
            }
            else if(checkX >= tileSize - activationRange){
                flag = false;
                trackController.advance(3);
                Debug.Log("FALSE");
            }
        }
        else{
            if(checkZ < tileSize - activationRange && checkZ > activationRange && checkX < tileSize - activationRange && checkX > activationRange){
                flag = true;
                Debug.Log("TRUE");
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log(checkZ + " < " + tileSize + " - " + activationRange + " && " + checkZ + " > " + activationRange
                             + " && " + checkX + " < " + tileSize + " - " + activationRange + " && " + checkX + " > " + activationRange);
            Debug.Log((checkZ < tileSize - activationRange) + "|" + (checkZ > activationRange) + "|" + (checkX < tileSize - activationRange) + "|" + (checkX > activationRange));
        }
    }
}
