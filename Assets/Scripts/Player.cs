using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{


    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform car;

    private float acceleration;
    private float steering;
    private float steeringRange = 0.5f;
    private float maxSpeed = 50;


    // [SerializeField] private GameObject camera; 
    // Start is called before the first frame update
    void Start()
    {
        acceleration = 0;
        steering = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // updateCamera();
        movement();
    }

    private void updateCamera()
    {
        // camera.transform.position = this.transform.localPosition;
    }

    private void movement()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            accelerate();
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            brake();
        }

        engineBrake();
        transform.Translate(Vector3.forward * acceleration * Time.deltaTime);

        if (acceleration > 0)
        {
            steer();
            Vector3 rotation = new Vector3(0, steering, 0);
            Quaternion deltaRotation = Quaternion.Euler(rotation * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        this.car.transform.localRotation = transform.localRotation;
        this.car.transform.localPosition = transform.localPosition;
    }

    private void accelerate()
    {
        if(acceleration < maxSpeed){
            acceleration = acceleration + 0.05f;
        }
    }

    private void brake()
    {
        if (acceleration > 0)
        {
            acceleration = acceleration - 0.1f;
        }
    }

    private void engineBrake()
    {
        if (acceleration > 0)
        {
            acceleration = acceleration - 0.01f;
        }
        else if (acceleration < 0)
        {
            acceleration = 0;
        }
    }

    private void steer()
    {
        if (steering < -steeringRange)
        {
            steering = steering + steeringRange;
        }
        else if (steering > +steeringRange)
        {
            steering = steering - steeringRange;
        }
        else if (steering != 0 && steering > -steeringRange && steering < steeringRange)
        {
            steering = 0;
        }
        if (steering > -steeringRange * 100 && steering < steeringRange * 100)
        {
            steering = steering + Input.GetAxis("Horizontal") * 8;
        }
    }
}
