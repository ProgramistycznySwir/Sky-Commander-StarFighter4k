using UnityEngine;

public class Player_Controler_v2 : MonoBehaviour
{
    [Header("Keyboard binding:")]
    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public EngineControler engineControler;

    // Update is called once per frame
    void Update()
    {
        engineControler.Turn(Input.GetAxis("Horizontal"));
        engineControler.Accelerate(Input.GetAxisRaw("Vertical"));
    }
}
