using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinvinController : MonoBehaviour
{
    public int id;
    public WheelCollider leftWheel, rightWheel;
    public float maxMotorTorque;
    public bool keyboardControl = false;

    // Start is called before the first frame update
    void Start()
    {
        leftWheel.steerAngle = 90f;
        rightWheel.steerAngle = 90f;

    }

    void FixedUpdate()
    {
        if(keyboardControl) {
            float leftTorque = maxMotorTorque * Input.GetAxis("Vertical");
            float rightTorque = maxMotorTorque * Input.GetAxis("Horizontal");

            leftWheel.motorTorque = leftTorque;
            rightWheel.motorTorque = rightTorque;
        }
    }

    public void setTorques(float leftTorque, float rightTorque) {
        leftWheel.motorTorque = leftTorque;
        rightWheel.motorTorque = rightTorque;
    }
}
