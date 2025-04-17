using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTNT : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < Camera.main.transform.position.x - 11f) //if it goes off the left side (I eyeballed it)
        {
            Destroy(gameObject); // DESTROYYYYYYYYYYYY
        }
    }
}