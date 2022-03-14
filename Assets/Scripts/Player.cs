using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{


    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Transform car;

    [SerializeField] private float acceleration;
    private float steering;
    private float steeringRange = 1f;
    private float maxSpeed = 50;
    private float minSpeed = 0;


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
        movement();
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
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
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
        if (acceleration > minSpeed)
        {
            acceleration = acceleration - 0.1f;
        }
    }

    private void engineBrake()
    {
        if (acceleration > minSpeed)
        {
            acceleration = acceleration - 0.01f;
        }
        else if (acceleration < minSpeed)
        {
            acceleration = minSpeed;
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

    public void restart(){
        this.steering = 0;
        this.acceleration = 0;
        this.minSpeed = 0;
        this.maxSpeed = 50;
    }

    public void updateMinSpeed(float additionSpeed){
        minSpeed += additionSpeed;
        if(minSpeed + additionSpeed > maxSpeed){
            maxSpeed = minSpeed;
        }
    }
}
