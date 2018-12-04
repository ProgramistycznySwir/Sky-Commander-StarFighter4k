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

    public float firerate = 1f;
    float firerateVAR = 0f;
    public float reloadRate = 1f;
    float reloadVAR = 0f;
    public int magazineSize = 50;
    public int rounds = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

        rounds = magazineSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (reloadVAR < 0 && rounds < magazineSize)
        {
            rounds++;
            reloadVAR = 1f;
        }
        else reloadVAR -= reloadRate * Time.deltaTime;

        Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(cursor.x - transform.position.x, cursor.y - transform.position.y);
        transform.up = direction;


        if (Input.GetMouseButton(0)) //if 
        {
            if (firerateVAR < 0 && rounds > 0)
            {
                int b = projectilesAtOnce;
                int c = 0;
                while (b > 0)
                {
                    GameObject newProjectile = Instantiate<GameObject>(projectile, barrelEnds[a].position + (barrelEnds[a].up * displacementInOneShot * c), barrelEnds[a].rotation);
                    if (deriveSpeed) newProjectile.GetComponent<Rigidbody2D>().velocity = ToVector2(newProjectile.transform.up) * projectileSpeed + gameObject.GetComponentInParent<Rigidbody2D>().velocity;
                    else newProjectile.GetComponent<Rigidbody2D>().velocity = ToVector2(newProjectile.transform.up) * projectileSpeed;
                    a++; b--; c++;
                    if (a >= barrelEnds.Length) a = 0;
                }
                firerateVAR = 1;
                rounds--; 
            }            
        }
        else reloadVAR -= reloadRate * Time.deltaTime; //if lmb is not pushed reloading is twice faster
        firerateVAR -= firerate * Time.deltaTime;
        //Debug.Log(Input.mousePosition);
    }
    public static Vector2 ToVector2(Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.y);
    }    
}
