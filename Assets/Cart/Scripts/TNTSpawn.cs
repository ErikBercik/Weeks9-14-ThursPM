using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTSpawn : MonoBehaviour
{
    public WheelSpin wheelSpin;
    public GameObject tntPrefab;
    //public int tntNumber = 1; //Just in case, I doubt I'll use too many


    void Start()
    {
        StartCoroutine(SpawnTNT());
    }

    IEnumerator SpawnTNT()
    {
        while(true)
        {
            GameObject newTNT = Instantiate(tntPrefab); //So we can alter it upon spawning
            Vector3 positionTNT = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width + Random.Range(0, 1500)), 60f, 1f)); //Yes this line is longer than my attention span, but it lets us spawn them outside of the camera view!
            newTNT.transform.position = positionTNT; //Spawn to the right of the screen!

            newTNT.AddComponent<DeleteTNT>(); //this guy LISTENS and enacts TNT desctruction 

            if (wheelSpin.startRotate != false) //if the wheels r spinnin'
            {
                newTNT.AddComponent<TNTMovement>(); //get the TNT movingggggg!
            }

            yield return new WaitForSeconds(3f); //I kept spawning too many, so a forum post recommended adding a delay of a few seconds! YAY
        }
    }
}
