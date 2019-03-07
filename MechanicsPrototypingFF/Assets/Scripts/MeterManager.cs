
#region Code Description
//Made by Moa Lindgren, 2019-03-05

//Following script handles the referensmeter,
//it generates random values for the referensmeter to go to.
//Communicates with InputHandler.
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterManager : MonoBehaviour
{
    [Header("Meter")]
    [SerializeField]
    Slider referensMeter;
    InputHandler inputHandler;

    float speed, approxValue, waitTime, rndValueToGo, maxValue, myValue;
    bool generateRandomValue, move, play;

    public float MyValue
    {
        get { return myValue; }
    }
    public float Speed
    {
        set { speed = value; }
    }
    public float ApproxValue
    {
        set { approxValue = value; }
    }
    public float WaitTime
    {
        set { waitTime = value; }
    }
    public bool Play
    {
        set
        {
            play = value;
            referensMeter.value = 0;
        }
    }

    void Start()
    {
        play = false;
        maxValue = referensMeter.maxValue;
        rndValueToGo = Random.Range(0, maxValue);
        move = true;
        inputHandler = GetComponent<InputHandler>();
    }
    void Update()
    {
        if(play)
        {
            myValue = referensMeter.value;
            if (move)
            {
                if (referensMeter.value < rndValueToGo)
                {
                    referensMeter.value += speed * Time.deltaTime;
                }
                else if (referensMeter.value > rndValueToGo)
                {
                    referensMeter.value -= speed * Time.deltaTime;
                }
                if (referensMeter.value - rndValueToGo < approxValue &&
                    referensMeter.value - rndValueToGo > -approxValue)
                {
                    move = false;
                    StartCoroutine(GenerateRandomValues());
                }
            }
        }
    }
    IEnumerator GenerateRandomValues()
    {
        yield return new WaitForSeconds(waitTime);
        rndValueToGo = Random.Range(0, maxValue);
        if(rndValueToGo != inputHandler.MyValue)
        {
            move = true;
        }
        //generates a new value if the value that was generated was equal to the players current value. Needs to be optimized since this could generate new values infinitly. 
        else
        {
            rndValueToGo = Random.Range(0, maxValue);
        }

    }
}
