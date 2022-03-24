using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private float yRotation = 4f;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(0.0f, yRotation, 0.0f, Space.Self);
    }

    private void onTriggerEnter(Collider other){
        // Player go = (Player) other;
        // gameManager.updateScore(50);
        Destroy(gameObject);
    }
}
