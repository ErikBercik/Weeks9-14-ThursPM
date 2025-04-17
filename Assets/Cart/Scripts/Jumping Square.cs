using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class JumpingSquare : MonoBehaviour
{
    public AnimationCurve jumpCurve;
    bool spacePressed = false;
    private float jumpingHeight = 5f;
    public float jumpLength = 1.3f; //This is a new line, so I could adjust timings
    //With how floaty it is, I should have called it float float!
    
    [Range(0, 1)]
    public float t;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !spacePressed) //basically like my first assignment, but cleaned up a bit
        {
            spacePressed = true;
            t = 0; 
        }

        if (spacePressed)
        {
            t += (Time.deltaTime / jumpLength);

            Vector3 pos = transform.position; //I got rid of the rotation here, uneeded
            pos.y = jumpCurve.Evaluate(t) * jumpingHeight - 2.9f;
            transform.position = pos; 

            if (t >= 1f)
            {
                spacePressed = false;
                t = 0;
            }
        }
    }
}
