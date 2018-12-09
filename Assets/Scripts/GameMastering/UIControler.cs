using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControler : MonoBehaviour
{
    public GameObject speedDisplayer;
    public GameObject inGameUI;
    public GameObject menu;


    public void ChangeUIDisplayedTo(int toWhichUI)
    {
        Debug.Log("not even reached switch...");
        switch (toWhichUI)
        {
            case 0:
                {
                    Menu(true);
                    InGameUI(false);
                    Debug.Log("Changed UI to Menu");
                    break;
                }
            case 1:
                {
                    Debug.Log("At least tried...");
                    Menu(false);
                    InGameUI(true);
                    Debug.Log("Changed UI to InGameUI");
                    break;
                }
            default:
                {
                    Debug.LogError("DEV: Something went teribelly wrong :(\n UIControler.ChangeUIDisplayed just got int out of range (see in switch)");
                    break;
                }
        }
    }

    public void InGameUI(bool open)
    {
        inGameUI.SetActive(open);
        speedDisplayer.SetActive(open);
    }
    public void Menu(bool open)
    {
        menu.SetActive(open);
    }
}
