
#region Code Description
//Made by Moa Lindgren, 2019-03-05

//Following script handles the values that the player gives in the inputfields.
//Later it instantiates the balancingmeter with these values.
//Communicates with UiManager, EventManager, MeterManager, and InputHandler.
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeGameValues : MonoBehaviour
{

    #region EventManager Values
    [Header("Process-Meter, editable variables")]
    [SerializeField]
    float processmeterSpeedUp;
    [SerializeField]
    float processmeterSpeedDown;
    [SerializeField]
    float processmeterApproxValue;
    [SerializeField]
    float processmeterStartValue;

    [Header("Game specifics")]
    [SerializeField]
    float gameTimer;
    [SerializeField]
    float looseTimer;
    [SerializeField]
    GameObject tempPlayer;
    [SerializeField]
    GameObject startPosition;

    [Header("Output info")]
    [Header("Variables needed depending on Loose Condition Index: " +
"1: LooseTimer. " +
"2: GameTimer. " +
"3: MaxNbrOfFails. ")]
    [SerializeField]
    int looseConditionIndex;
    [SerializeField]
    int maxNbrOfFails;
    #endregion

    #region InputHandler Values
    [Header("Player-Meter, editable variables")]
    [SerializeField]
    float meterDownSpeed;
    [SerializeField]
    float meterUpSpeed;
    #endregion

    #region MeterManager Values
    [Header("Referens-Meter, editable variables")]
    [SerializeField]
    float referencemeterSpeed;
    [SerializeField]
    float referencemeterApproxValue;
    [SerializeField]
    float referencemeterWaitTime;
    #endregion

    [Header("Input info")]
    [SerializeField]
    List<GameObject> inputFields;
    [SerializeField]
    GameObject balancingMeter;

    UiManager uiManager;
    EventManager eventManager;
    MeterManager meterManager;
    InputHandler inputHandler;

    bool defaultValues;
    float inputValue;

    void Start()
    {
        eventManager = balancingMeter.GetComponent<EventManager>();
        meterManager = balancingMeter.GetComponent<MeterManager>();
        inputHandler = balancingMeter.GetComponent<InputHandler>();
        SetValues();
    }

    public void SetValues()
    {
        eventManager.SpeedUp = processmeterSpeedUp;
        eventManager.SpeedDown = processmeterSpeedDown;
        eventManager.ApproxValue = processmeterApproxValue;
        eventManager.StartValue = processmeterStartValue;
        eventManager.GameTimer = gameTimer;
        eventManager.LooseTimer = looseTimer;
        eventManager.TempPlayer = tempPlayer;
        eventManager.StartPosition = startPosition;
        eventManager.LooseConditionIndex = looseConditionIndex;
        eventManager.MaxNbrOfFails = maxNbrOfFails;

        inputHandler.MeterUpSpeed = meterUpSpeed;
        inputHandler.MeterDownSpeed = meterDownSpeed;

        meterManager.Speed = referencemeterSpeed;
        meterManager.ApproxValue = referencemeterApproxValue;
        meterManager.WaitTime = referencemeterWaitTime;

    }



    public void DefaultValues()
    {
        defaultValues = !defaultValues;
    }


    public void GetIndext(int inputFieldIndex)
    {
        string input = inputFields[inputFieldIndex].GetComponent<InputField>().text;
        float.TryParse(input, out inputValue);
    }


}
