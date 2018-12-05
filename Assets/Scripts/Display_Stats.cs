using System.Collections;
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

    [Header("Health:")]
    public UnityEngine.UI.Text healthText;
    public UnityEngine.UI.Image healthBar;

    [Header("Stun:")]
    public UnityEngine.UI.Image stunImageBlack;
    public UnityEngine.UI.Image stunImageWhite;

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
        if (shipWhichSpeedDisplay.GetComponent<Rigidbody2D>().velocity.magnitude > shipWhichSpeedDisplay.GetComponent<Stats>().maxVelocity) text.color = speedWarningColor;
        else text.color = basicTextColor;
        speedMeter.fillAmount = shipWhichSpeedDisplay.GetComponent<Rigidbody2D>().velocity.magnitude / (shipWhichSpeedDisplay.GetComponent<Stats>().maxVelocity *2);
        if (shipWhichSpeedDisplay.transform.GetChild(2).GetComponent<Weapon_Control_System>()) ammoText.text = Convert.ToString(shipWhichSpeedDisplay.transform.GetChild(2).GetComponent<Weapon_Control_System>().rounds);
        if (shipWhichSpeedDisplay.transform.GetChild(2).GetComponent<Weapon_Control_System>()) ammoBar.fillAmount = Convert.ToSingle(shipWhichSpeedDisplay.transform.GetChild(2).GetComponent<Weapon_Control_System>().rounds) / Convert.ToSingle(shipWhichSpeedDisplay.transform.GetChild(2).GetComponent<Weapon_Control_System>().magazineSize);

        healthText.text = Convert.ToString(shipWhichSpeedDisplay.GetComponent<Stats>().health);
        healthBar.fillAmount = Convert.ToSingle(shipWhichSpeedDisplay.GetComponent<Stats>().health / shipWhichSpeedDisplay.GetComponent<Stats>().maxHealth);

        stunImageBlack.color = new Color(0, 0, 0, Convert.ToSingle(shipWhichSpeedDisplay.GetComponent<EngineControler>().stun) / Convert.ToSingle(shipWhichSpeedDisplay.GetComponent<EngineControler>().stunDuration) / 3f);
        stunImageWhite.color = new Color(1, 1, 1, Convert.ToSingle(shipWhichSpeedDisplay.GetComponent<EngineControler>().stun) / Convert.ToSingle(shipWhichSpeedDisplay.GetComponent<EngineControler>().stunDuration) / 3f);
    }
}
