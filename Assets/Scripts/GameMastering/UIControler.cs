using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControler : MonoBehaviour
{
    public GameObject speedDisplayer;
    public GameObject inGameUI;
    public GameObject menu;


    public void ChangeUIDisplayed(int toWhichUI)
    {

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
