using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Control_System : MonoBehaviour
{
    [Header("Cursor:")]
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    [Header("Sockets:")]
    public Turret_Control[] turrets;
    public Rocket_Launcher_Script[] rocketLaunchers;
    public Front_Canon_Control[] frontCannons;

    public KeyCode fireTurrets;
    public KeyCode fireRockets;
    public KeyCode fireFrontalCannons;

    [SerializeField]
    public int rounds, magazineSize;

    //Transform cursorTransform;


    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        for(int a=0; a < frontCannons.Length; a++)
        {            
            magazineSize += frontCannons[a].magazineSize;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //cursorTransform.position = cursor;
        //Vector2 direction = new Vector2(cursor.x - transform.position.x, cursor.y - transform.position.y);
        //transform.up = direction;

        rounds = 0;

        int a = 0;
        while (a < frontCannons.Length)
        {
            frontCannons[a].target = cursor;
            if (Input.GetMouseButton(0))
            {
                frontCannons[a].Fire();
            }            
            rounds += frontCannons[a].rounds;
            a++;
        }
        
    }
}
