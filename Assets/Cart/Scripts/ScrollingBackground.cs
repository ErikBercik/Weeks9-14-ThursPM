using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    public Renderer r;
    public WheelSpin wheelSpin; //let's reuse this public WheelSpin wheelSpin; //let's reuse this
    float speed = .1f; //this is going to be tied in with the cart speed, and the speed lines visible
    //Nevermind, speed is outside the scope of the project... Unless it gets paused

    // This is directly based off of the reading materials
    void Update()
    {
        if (wheelSpin.startRotate != false) //if the wheels r spinnin'
        {
            r.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0); //get the background movin'
        }
    }
}


