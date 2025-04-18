using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTSpawn : MonoBehaviour
{
    public WheelSpin wheelSpin;
    public bool boom = false;
    public GameObject tntPrefab;
    public float yPos = 0.15f; //They keep spawning all over the place with fixed variables
    public GameObject cart; //I need to check for the cart's positionnnn
    //public int tntNumber = 1; //Just in case, I doubt I'll use too many

    public List<GameObject> spawnedTNT = new List<GameObject>(); // That extra reading on lists came in handy eh...?


    void Start()
    {
        StartCoroutine(SpawnTNT());
    }

    private void Update()
    {
        // if (wheelSpin.startRotate == false) //if the wheels stawp
        // {
        //     StopCoroutine(SpawnTNT()); //Stop throwing the TNT!
        // }
        //for (int i = 0;  i < spawnedTNT.Count; ++i) //for each item in the list (aka our tnts that got spawned!)
        //{
        //    GameObject tnt = spawnedTNT[i]; //go down the list and make some CZECHS (some expatriot humour)
        //
        //    if (cart.GetComponent<SpriteRenderer>().bounds.Contains(tnt.GetComponent<SpriteRenderer>().bounds.center)) //I won't lie, a classmate helped me figure this out.
        //    {
        //        boom = true;
        //    }
        //}
        
        //Unfortunately all of this causes nonstop error, I assume because I need to delete it from the list when it is deleted. That said, without being able to set the functionality, I'll just add a button...

    }

    IEnumerator SpawnTNT()
    {
        while(wheelSpin.startRotate) //This one change was much easier than messing with the Update...
        {
            GameObject newTNT = Instantiate(tntPrefab); //So we can alter it upon spawning
            Vector3 positionTNT = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width + Random.Range(0, 1500)), (Screen.height * yPos), 1f)); //Yes this line is longer than my attention span, but it lets us spawn them outside of the camera view!
            newTNT.transform.position = positionTNT; //Spawn to the right of the screen!

            newTNT.AddComponent<DeleteTNT>(); //this guy LISTENS and enacts TNT desctruction 

            if (wheelSpin.startRotate != false) //if the wheels r spinnin'
            {
                newTNT.AddComponent<TNTMovement>(); //get the TNT movingggggg!
            }

            //yield return new WaitForSeconds(0.1f); //OMG I needed a delay

            //if (cart.GetComponent<SpriteRenderer>().bounds.Contains(newTNT.GetComponent<SpriteRenderer>().bounds.center)) //I won't lie, a classmate helped me figure this out.
            //{
            //    boom = true;
            //}
            // This kinda works..? but I think not continuously, needs to be moved to Update?

            //spawnedTNT.Add(newTNT); //let's add these guys to our list, to kleep trackof where they are

            yield return new WaitForSeconds(3f); //I kept spawning too many, so a forum post recommended adding a delay of a few seconds and then I remembered we could do that! YAY
        }
    }
}
