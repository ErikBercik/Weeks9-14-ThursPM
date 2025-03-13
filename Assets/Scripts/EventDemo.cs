using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDemo : MonoBehaviour
{

    public RectTransform banana;



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
