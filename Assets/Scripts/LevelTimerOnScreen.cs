using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimerOnScreen : MonoBehaviour
{

    public GameObject textDisplay;
    public float SecondsLeft = 60.00f;
    public bool takingAway = false;
    
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "Time: " + SecondsLeft.ToString();
    }

   
    void Update()
    {
        if(takingAway == false && SecondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }


    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1f);
        SecondsLeft -= 1;
        textDisplay.GetComponent<Text>().text = "Time: " + SecondsLeft.ToString();
        takingAway = false;
    }
}

