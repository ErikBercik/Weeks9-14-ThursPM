using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public float timeAnHourTakes = 5;

    public float t;
    public int hour = 0;

    //public UnityEvent OnTheHour;  //This is a normal way to show the variable... but to pass the value on you need:
    public UnityEvent<int> OnTheHour; //this will pass an integer argument!

    public Transform hourHand;
    public Transform minuteHand;

    private Coroutine clockIsRunning; //This is telling our cookie cutter to turn on or off
    private IEnumerator doOneHour;
    //private IEnumerator doOneBoop; me trying to make a bird pop out

    public Object birdObject;

    private void Start()
    {
        //this calls the coroutine to run once (the loop with in it runs many times). If you put this in update, it will compound the speed! Oops!
        //StartCoroutine(MoveTheClockHandsOneHour());


        clockIsRunning = StartCoroutine(MoveTheClock());
        //This variable means this particular instance is running

        

    }

    IEnumerator MoveTheClock()
    {
        while (true) //while the value is true (aka run forever)
        {

            //yield return StartCoroutine(MoveTheClockHandsOneHour()); This works! But what if we want to stop the hands midway?

            //yield return dooneHour = StartCoroutine(MoveTheClockHandsOneHour());   // AKA start routine, remember what it is in the variable, and stop when we come back
            //this is messy though... what else can we do?

            doOneHour = MoveTheClockHandsOneHour();
            yield return StartCoroutine(doOneHour);

        }

        ////if we add a yield outside the coroutine, unity not happy... but logically this gives us the power to repeat
        //yield return StartCoroutine(MoveTheClockHandsOneHour());
        ////Once finished, it will move on to this:
        //yield return StartCoroutine(MoveTheClockHandsOneHour());

    }


    void Update()
    {
        //no longer needed with a coroutine!
        //t += Time.deltaTime;

        ////This is switched from an if statement to a while statement, flip the > to a < then
        //while (t < timeAnHourTakes)
        //{
        //    t = 0;
        //    OnTheHour.Invoke();

        //    hour++;
        //    if (hour == 12)
        //    {
        //        hour = 0;
        //    }
        //}
    }

    IEnumerator MoveTheClockHandsOneHour()
    {
        t = 0;
        while(t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            //this determines how far the hand will rotate (360) but in how long? Over time! And - so it rotates clockwise
            minuteHand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            //same for hour hand, same logic at least but different values
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            //this is the coroutine magic
            yield return null; 
            //this is basically saying, come back to this bookmark and do another frame, keep coming back UNTIL While isn't true anymore
        }

        //after it does all that stuff, it moves on to this line
        hour++; //add 1 to the value of "hour"

        if(hour == 13)
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);   //This will be used by KitChime script!

    }

    public void StopTheClock()
    {
        if(clockIsRunning != null) // (this line stops a null error in case the function never ran in the first place)
        {
            StopCoroutine(clockIsRunning); //Referring back to that variable we made (Like a GameObject referring to itself)
                                           //This by itself stops the coroutine from repeating, but won't stop the hands mid-move...
        }

        if(doOneHour != null)
        {
            StopCoroutine(doOneHour);
            //And bam, there we go!
        }

    }

   // public void CuckooPopsOut()
   // {
   // }
}
