
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
    UiManager uiManager;
    EventManager eventManager;
    MeterManager meterManager;
    InputHandler inputHandler;

    [SerializeField]
    List<GameObject> inputFields;
    [SerializeField]
    List<float> eventManagerValues, inputManagerValues, meterManagerValues;
    [SerializeField]
    GameObject balancingMeter;

    bool defaultValues;
    float inputValue;


    void Start()
    {
        uiManager = GetComponent<UiManager>();

        //following needs to be set after instantiating balancingmeter, but currently it can be set from start. 
        eventManager = balancingMeter.GetComponent<EventManager>();
        meterManager = balancingMeter.GetComponent<MeterManager>();
        inputHandler = balancingMeter.GetComponent<InputHandler>();
    }
    public void DefaultValues()
    {
        defaultValues = !defaultValues;
    }

    public void SetGameValues()
    {
        if (!defaultValues)
        {
            //foreach (float value in inputValues)
            //{
            //    if (value != 0)
            //    {

            //    }
            //    else
            //    {
            //        //message to fill empty area
            //    }
            //}
        }
        else
        {
            //Instantiate balancingmeter without any adjustments.
        }
    }
    public void GetIndext(int inputFieldIndex)
    {
        string input = inputFields[inputFieldIndex].GetComponent<InputField>().text;
        float.TryParse(input, out inputValue);
    }
    public void GetInputField(string inputField)
    {
        switch (inputField)
        {
            case "ProcessMeter":
                return;
            case "PlayerMeter":
                return;
            case "ReferensMeter":
                return;

        }
    }

}
