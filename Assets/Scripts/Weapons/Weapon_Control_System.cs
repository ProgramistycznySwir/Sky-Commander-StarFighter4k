using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Control_System : MonoBehaviour
{
    public Stats stats;

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
        if (turrets != null)
            foreach (Turret_Control turret in turrets)
            {
                magazineSize += turret.magazineSize;
                turret.stats = stats;
            }

        if (frontCannons != null)
            foreach (Front_Canon_Control frontCannon in frontCannons)
            {
                magazineSize += frontCannon.magazineSize;
                frontCannon.stats = stats;
            }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //cursorTransform.position = cursor;
        //Vector2 direction = new Vector2(cursor.x - transform.position.x, cursor.y - transform.position.y);
        //transform.up = direction;

        rounds = 0;
        if (turrets != null)
        {
            int a = 0;
            while (a < turrets.Length)
            {
                rounds += turrets[a].rounds;
                a++;
            }
        }


        if (frontCannons != null)
        {
            int a = 0;
            while (a < frontCannons.Length)
            {
                rounds += frontCannons[a].rounds;
                a++;
            }
        }
    }

    public void AimAt(Vector3 target)
    {
        if (turrets != null)
            for(int i = 0; i < turrets.Length; i++)
                turrets[i].target = target;

        if (frontCannons != null)
            for(int i = 0; i < frontCannons.Length; i++)
                frontCannons[i].target = target;
    }

    public void Fire(bool fireTurrets, bool fireFrontCannons)
    {
        if (turrets != null)
            for(int i = 0; i < turrets.Length; i++)
                turrets[i].Fire();

        if (frontCannons != null)
            for(int i = 0; i < frontCannons.Length; i++)
                frontCannons[i].Fire();
    }
}
