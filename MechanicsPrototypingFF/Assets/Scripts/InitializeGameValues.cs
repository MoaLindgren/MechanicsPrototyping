
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

    bool defaultValues;
    [SerializeField]
    List<GameObject> inputFields;
    [SerializeField]
    List<float> inputValues;
    [SerializeField]
    GameObject balancingSlider;

    void Start()
    {
        uiManager = GetComponent<UiManager>();
        //following needs to be set after instantiating balancingmeter, but currently it can be set from start. 
        eventManager = balancingSlider.GetComponent<EventManager>();
        meterManager = balancingSlider.GetComponent<MeterManager>();
        inputHandler = balancingSlider.GetComponent<InputHandler>();
    }
    public void DefaultValues()
    {
        defaultValues = !defaultValues;
    }

    public void SetGameValues()
    {
        if (!defaultValues)
        {
            //Sätt alla scripts redigeringsbara-värden till de värden spelaren la in.
            foreach (float value in inputValues)
            {
                if (value != 0)
                {

                }
                else
                {
                    //message to fill empty area
                }
            }
        }
        else
        {
            //Instantiate balancingmeter without any adjustments.
        }
    }
    public void GetInput(int inputFieldIndex)
    {
        string input = inputFields[inputFieldIndex].GetComponent<InputField>().text;
        float inputValue;
        if (float.TryParse(input, out inputValue))
        {
            inputValues[inputFieldIndex] = inputValue;
        }

    }

}
