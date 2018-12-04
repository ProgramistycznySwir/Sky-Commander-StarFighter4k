using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler_v2 : MonoBehaviour
{
    public KeyCode forward = KeyCode.W, backward = KeyCode.S, left = KeyCode.A, right = KeyCode.D;



    // Update is called once per frame
    void Update()
    {
        bool doneShit = false;
        if (Input.GetKey(left))
        {
            gameObject.GetComponent<EngineControler>().TurnLeft();
            doneShit = true;
        }
        else if (Input.GetKey(right))
        {
            gameObject.GetComponent<EngineControler>().TurnRight();
        }
        else
        {
            if (Input.GetKey(forward))
            {
                gameObject.GetComponent<EngineControler>().Accelerate();
                if (doneShit)
                {
                    Debug.Log("DEBIL");
                }
            }
            if (Input.GetKey(backward))
            {
                gameObject.GetComponent<EngineControler>().Deaccelerate();
                
            }
        }
        
    }
}
