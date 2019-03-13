
#region Code Description
//Made by Moa Lindgren, 2019-03-05

//Following script handles the full game process.
//If processmeter is full the player wins, and if loosecondition is true the playes fails.
//Communicates with InputHandler, MeterManager and UiManager.
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [Header("Meter")]
    [SerializeField]
    Slider processMeter;
    InputHandler inputHandler;
    MeterManager meterManager;
    UiManager uiManager;
    GameObject tempPlayer, startPosition;

    int looseConditionIndex, maxNbrOfFails, uiOutput, countFails;
    float speedUp, speedDown, approxValue, looseTimer, startValue, gameTimer, playerValue, referensValue, looseTimerCounter, gameTimerCounter;
    bool fill, play;


    public float SpeedUp
    {
        set { speedUp = value; }
    }
    public float SpeedDown
    {
        set { speedDown = value; }
    }
    public float ApproxValue
    {
        set { approxValue = value; }
    }
    public float LooseTimer
    {
        set { looseTimer = value; }
    }
    public float StartValue
    {
        set { startValue = value; }
    }
    public float GameTimer
    {
        set { gameTimer = value; }
    }
    public int LooseConditionIndex
    {
        set { looseConditionIndex = value; }
    }
    public int MaxNbrOfFails
    {
        set { maxNbrOfFails = value; }
    }
    public GameObject TempPlayer
    {
        set { tempPlayer = value; }
    }
    public GameObject StartPosition
    {
        set { startPosition = value; }
    }


    public bool Play
    {
        set
        {
            play = value;
            ResetGame();
        }
    }
    void Start()
    {
        fill = false;
        looseTimerCounter = looseTimer;
        gameTimerCounter = gameTimer;
        inputHandler = GetComponent<InputHandler>();
        meterManager = GetComponent<MeterManager>();
        uiManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<UiManager>();
    }
    void Update()
    {
        if (play)
        {
            playerValue = inputHandler.MyValue;
            referensValue = meterManager.MyValue;

            //fill = true when the players meter-icon is within the approxvalue to the referensmeter.
            if (playerValue - referensValue < approxValue &&
               playerValue - referensValue > -approxValue)
            {
                fill = true;
            }
            else
            {
                fill = false;
            }

            //the processmeter fills up when fill=true, and goes down when fill=false.
            if (fill)
            {
                looseTimerCounter = looseTimer;
                uiManager.HideUiText();
                processMeter.value += speedUp * Time.deltaTime;
            }
            else if (!fill)
            {
                processMeter.value -= speedDown * Time.deltaTime;
            }

            //win and loose conditions:
            if (processMeter.value == processMeter.maxValue)
            {
                GameOver(true);
            }
            else
            {
                switch (looseConditionIndex)
                {
                    //If the processmeters value = 0 -> timer starts.
                    //If the timers value = 0 -> player loose.
                    case 1:
                        if (processMeter.value == processMeter.minValue)
                        {
                            looseTimerCounter -= Time.deltaTime;
                            uiOutput = Mathf.RoundToInt(looseTimerCounter);
                            uiManager.OutPutText = uiOutput.ToString();
                            if (looseTimerCounter <= 0)
                            {
                                GameOver(false);
                                looseTimerCounter = looseTimer;
                            }
                        }
                        return;

                    //If the gametimer is at 0 -> player loose.
                    case 2:
                        gameTimerCounter -= Time.deltaTime;
                        uiOutput = Mathf.RoundToInt(gameTimerCounter);
                        uiManager.OutPutText = uiOutput.ToString();
                        if (gameTimerCounter <= 0)
                        {
                            GameOver(false);
                            gameTimerCounter = gameTimer;
                        }
                        return;

                    //If the player fails (processmeters value = 0) too many times.
                    case 3:
                        if (processMeter.value == processMeter.minValue)
                        {
                            countFails++;
                            uiOutput = Mathf.RoundToInt(countFails); //showGameTimer = true; <<<<<<< ISTÄLLET FÖR DETTA.
                            uiManager.OutPutText = uiOutput.ToString();
                            processMeter.value = startValue;

                            if (countFails >= maxNbrOfFails)
                            {
                                GameOver(false);
                                countFails = 0;
                            }
                        }
                        return;
                }
            }
        }
    }
    void GameOver(bool win)
    {
        play = false;
        meterManager.Play = this.play;
        inputHandler.Play = this.play;

        //following is where output-event can be called:
        switch (win)
        {
            case true:
                uiManager.OutPutText = "YOU WON";
                return;
            case false:
                uiManager.OutPutText = "YOU LOST";
                //output-event:
                tempPlayer.GetComponent<Rigidbody>().useGravity = true;
                return;
        }
    }

    void ResetGame()
    {
        inputHandler.Play = this.play;
        meterManager.Play = this.play;
        processMeter.value = startValue;
        tempPlayer.GetComponent<Rigidbody>().useGravity = false; //Resetting output-event
        tempPlayer.transform.position = startPosition.transform.position;
        fill = false;
        countFails = 0;
        looseTimerCounter = looseTimer;
        gameTimerCounter = gameTimer;

    }
}
