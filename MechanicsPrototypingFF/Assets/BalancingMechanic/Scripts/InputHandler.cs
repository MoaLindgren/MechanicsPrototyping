
#region Code Description
//Made by Moa Lindgren, 2019-03-05

//Following script handles the players input during game.
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [Header("Meter")]
    [SerializeField]
    Slider playerMeter;

    float meterDownSpeed, meterUpSpeed, myValue;
    bool playerInput, play;

    public float MyValue
    {
        get { return myValue; }
    }
    public float MeterDownSpeed
    {
        set { meterDownSpeed = value; }
    }
    public float MeterUpSpeed
    {
        set { meterUpSpeed = value; }
    }
    public bool Play
    {
        set
        {
            play = value;
            playerMeter.value = 0;
        }
    }

    void Start()
    {
        playerInput = false;
    }
    void Update()
    {
        if(play)
        {
            myValue = playerMeter.value;
            if (playerInput)
            {
                playerMeter.value += meterUpSpeed * Time.deltaTime;
            }
            else if (!playerInput)
            {
                playerMeter.value -= meterDownSpeed * Time.deltaTime;
            }
        }
    }
    public void ButtonDown()
    {
        playerInput = true;
    }
    public void ButtonUp()
    {
        playerInput = false;
    }
}
