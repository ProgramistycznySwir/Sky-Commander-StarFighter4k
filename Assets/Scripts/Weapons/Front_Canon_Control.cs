using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Front_Canon_Control : MonoBehaviour
{
    [Header("Barrel ends:")]
    public Transform[] barrelEnds;

    [Header("Projectile:")]
    public GameObject projectile;
    public float projectileSpeed;
    public bool deriveSpeed = true;
    public int projectilesAtOnce = 1;
    public float displacementInOneShot = -0.005f;
    int a;

    [Header("Firerate and Reloading:")]
    public float firerate = 1f;
    float firerateVAR = 0f;
    public float reloadRate = 1f;
    float reloadVAR = 0f;
    public int magazineSize = 50;
    [HideInInspector]
    public int rounds = 0;

    [Header("Front Cannon Specific Settings:")]
    [Tooltip("From what angle to what angle the cannon can turn (odwrotne od kartezjańskiego)")]
    public Vector2 limits;

    [SerializeField]
    public Vector3 target;

    bool firingThisFrame = false;

    void Start()
    {
        rounds = magazineSize;
    }
    

    void FixedUpdate()
    {
        
        if (reloadVAR < 0 && rounds < magazineSize)
        {
            rounds++;
            reloadVAR = 1f;
        }
        else reloadVAR -= reloadRate * Time.deltaTime;
        
        Vector2 direction = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        transform.up = direction;

        if(!firingThisFrame) 
        {
            reloadVAR -= reloadRate * Time.deltaTime; //if lmb is not pushed reloading is twice faster
            firingThisFrame = false;
        }
        
        float sumValue = 0f;
        sumValue = transform.localEulerAngles.z;
        if(transform.localEulerAngles.z > 180)
        {
            sumValue = transform.localEulerAngles.z - 360;
        }

        if (sumValue > limits.x)
        {
            transform.eulerAngles.Set(0,0,limits.x + transform.parent.transform.up.z);//transform.localEulerAngles.Set(0, 0, limits.x);
            Debug.Log("Doin' ma part");
        }
        else if (sumValue < limits.y) transform.localEulerAngles.Set(0, 0, 360 - limits.y);
        Debug.Log(transform.localEulerAngles.z + " / " + sumValue + " / " + limits.x);

        firerateVAR -= firerate * Time.deltaTime;
        //Debug.Log(Input.mousePosition);
    }

    public void Fire()
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
        firingThisFrame = true;
    }
    public static Vector2 ToVector2(Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.y);
    }
}
