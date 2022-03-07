using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBall : MonoBehaviour
{
    private int prefix = 1;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.Rotate(-45.0f, 0.0f, 0.0f, Space.Self);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(prefix * function(counter), 0.0f, 0.0f, Space.Self);
        counter++;
        if (counter == 130)
        {
            counter = 0;
            prefix *= -1;
        }
    }

    private float function(float x)
    {
        return -(1f / 4225f) * (x * x) + (2f / 65f) * x;
    }
}
