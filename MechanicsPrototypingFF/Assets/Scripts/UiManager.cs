
#region Code Description
//Made by Moa Lindgren, 2019-03-05

//Following script handles the ui-elements in the game. For example, if there is a timer, it shows through this script.
//Communicates with EventManager.
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("Ui Elements")]
    [SerializeField]
    Text uiText;
    [SerializeField]
    GameObject balancingMeter;
    EventManager eventManager;
    string outPutText;

    public string OutPutText
    {
        set
        {
            outPutText = value;
            ShowUiText();
        }
    }

    void Start()
    {
        eventManager = balancingMeter.GetComponent<EventManager>();
    }

    void ShowUiText()
    {
        uiText.text = outPutText;
        uiText.gameObject.SetActive(true);
    }
    public void HideUiText()
    {
        uiText.gameObject.SetActive(false);
    }

    //called from play-button in ui, and when winning/loosing:
    public void Play()
    {
        eventManager.Play = true;
    }
}
