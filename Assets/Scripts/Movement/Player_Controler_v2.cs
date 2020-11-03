using UnityEngine;

public class Player_Controler_v2 : MonoBehaviour
{
    [Header("Keyboard binding:")]
    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public EngineControler engineControler;
    public Weapon_Control_System weapon_Control_System;

    // Update is called once per frame
    void Update()
    {
        engineControler.Turn(Input.GetAxis("Horizontal"));
        engineControler.Accelerate(Input.GetAxisRaw("Vertical"));

        weapon_Control_System.AimAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        weapon_Control_System.Fire(Input.GetMouseButton(0), Input.GetMouseButton(1));
    }
}
