using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipUI : MonoBehaviour
{
    public EngineControler engineControler;
    public TextMeshProUGUI speedText;
    public UnityEngine.UI.Image speedBar;
    public UnityEngine.UI.Image overspeedBar;


    public Stats stats;
    public TextMeshProUGUI hpText;
    public UnityEngine.UI.Image hpBar;

    public TextMeshProUGUI shdText;
    public UnityEngine.UI.Image shdBar;

    // Update is called once per frame
    void Update()
    {
        // Speed
        speedText.text = $"v: {engineControler.rigidbody.velocity.magnitude.ToString("F1")}";
        speedBar.fillAmount = engineControler.rigidbody.velocity.magnitude / engineControler.MaxVelocity;
        overspeedBar.fillAmount = (engineControler.rigidbody.velocity.magnitude / engineControler.MaxVelocity) - 1f;

        // HP
        hpText.text = $"HP: {stats.hp.value.ToString("F0")}/{stats.hp.max.ToString("F0")}";
        hpBar.fillAmount = stats.hp.Percent;
    }
}
