using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Display_Speed : MonoBehaviour
{
    public UnityEngine.UI.Text text;
    public UnityEngine.UI.Image speedMeter;
    public Rigidbody2D shipWhichSpeedDisplay;
    public float maxVelocity = 20f;
    

    // Update is called once per frame
    void Update()
    {
        text.text = Convert.ToString(Convert.ToInt16( shipWhichSpeedDisplay.velocity.magnitude * 100));
        speedMeter.fillAmount = shipWhichSpeedDisplay.velocity.magnitude / (maxVelocity *2);
    }
}
