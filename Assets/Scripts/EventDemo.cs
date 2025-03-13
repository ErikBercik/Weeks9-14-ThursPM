using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDemo : MonoBehaviour
{

    public RectTransform banana;

    public UnityEvent OnTimerHasFinished;
    public float timerLength = 3;
    public float t;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseHasArrived()
    {
        Debug.Log("Yer in ma swamp donkeh");
        banana.localScale = Vector3.one * 2;
    }

    public void MouseHasLeft()
    {
        Debug.Log("Get out of meh swamp!");
        banana.localScale = Vector3.one;
    }


}
