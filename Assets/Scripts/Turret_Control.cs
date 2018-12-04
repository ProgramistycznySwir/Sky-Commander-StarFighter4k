using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Control : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Transform[] barrelEnds;
    public GameObject projectile;
    public float projectileSpeed;
    public bool deriveSpeed = true;
    public int projectilesAtOnce = 1;
    public float displacementInOneShot = -0.005f;
    int a;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(cursor.x - transform.position.x, cursor.y - transform.position.y);
        transform.up = direction;

        if (Input.GetMouseButton(0))
        {
            int b = projectilesAtOnce;
            int c = 0;
            while (b > 0)
            {
                GameObject newProjectile = Instantiate<GameObject>(projectile, barrelEnds[a].position + (barrelEnds[a].up * displacementInOneShot * c), barrelEnds[a].rotation);
                if (deriveSpeed)  newProjectile.GetComponent<Rigidbody2D>().velocity = ToVector2(newProjectile.transform.up) * projectileSpeed + gameObject.GetComponentInParent<Rigidbody2D>().velocity;
                else newProjectile.GetComponent<Rigidbody2D>().velocity = ToVector2(newProjectile.transform.up) * projectileSpeed;
                a++; b--; c++; 
                if (a >= barrelEnds.Length) a = 0;
            }            
        }

        //Debug.Log(Input.mousePosition);
    }
    public static Vector2 ToVector2(Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.y);
    }    
}
