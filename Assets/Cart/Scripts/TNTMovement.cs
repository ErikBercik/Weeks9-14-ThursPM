using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTMovement : MonoBehaviour
{
    private float speedTNT = -6f;

    void Update()
    {
            TNTMove(); //get the TNT movin'
    }

    public void TNTMove() //Casual movement to the left, nothing special
    {
        Vector3 pos = transform.position;
        pos.x += speedTNT * Time.deltaTime;
        transform.position = pos;
    }

}
