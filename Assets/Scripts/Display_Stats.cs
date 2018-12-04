﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Display_Stats : MonoBehaviour
{
    [Header("Speed:")]
    public UnityEngine.UI.Text text;
    public UnityEngine.UI.Image speedMeter;

    [Header("Ammo:")]
    public UnityEngine.UI.Text ammoText;
    public UnityEngine.UI.Image ammoBar;

    [Header("Sockets:")]
    public GameObject shipWhichSpeedDisplay;
    public Color speedWarningColor = Color.red;
    Color basicTextColor;

    void Start()
    {
        basicTextColor = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Convert.ToString(Convert.ToInt16( shipWhichSpeedDisplay.GetComponent<Rigidbody2D>().velocity.magnitude * 100));
        ammoText.text = Convert.ToString(shipWhichSpeedDisplay.transform.GetChild(2).GetComponent<Turret_Control>().rounds);
        if (shipWhichSpeedDisplay.GetComponent<Rigidbody2D>().velocity.magnitude > shipWhichSpeedDisplay.GetComponent<Stats>().maxVelocity) text.color = speedWarningColor;
        else text.color = basicTextColor;
        speedMeter.fillAmount = shipWhichSpeedDisplay.GetComponent<Rigidbody2D>().velocity.magnitude / (shipWhichSpeedDisplay.GetComponent<Stats>().maxVelocity *2);
        ammoBar.fillAmount = Convert.ToSingle(shipWhichSpeedDisplay.transform.GetChild(2).GetComponent<Turret_Control>().rounds) / Convert.ToSingle(shipWhichSpeedDisplay.transform.GetChild(2).GetComponent<Turret_Control>().magazineSize);
    }
}