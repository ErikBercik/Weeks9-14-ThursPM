using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePaused : MonoBehaviour
{

    public bool isPaused = false; //game is going until......

    void Start()
    {
        StartCoroutine(IsPaused()); //
    }

    void Update()
    {
        
    }

    IEnumerator IsPaused()
    {
        while(isPaused == true)
        yield return null;
    }
}

//AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH