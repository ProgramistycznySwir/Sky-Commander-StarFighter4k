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

    // Update is called once per frame
    void Update()
    {
        // Speed
        speedText.text = $"v: {engineControler.rigidbody.velocity.magnitude.ToString("F1")}";
        speedBar.fillAmount = engineControler.rigidbody.velocity.magnitude / engineControler.maxVelocity;
        overspeedBar.fillAmount = (engineControler.rigidbody.velocity.magnitude / engineControler.maxVelocity) - 1f;
    }
}
