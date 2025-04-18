using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{

    public bool startRotate = true; 


    private void Update()
    {
        if(startRotate == true) //if it should rotate, it will!
        {
            RotateWheel();
        }
    }

    public void StartRotate() //This will trigger the following function
    {
        startRotate = true;
    }

    private void RotateWheel() //Make the wheels on the bus go round and round!
    {
        Vector3 rot = transform.eulerAngles;
        rot.z += -1;
        transform.eulerAngles = rot;
    }

    public void StopRotate() //my manual way of stopping the rotation with a button
    {
        startRotate = false;
    }
}
