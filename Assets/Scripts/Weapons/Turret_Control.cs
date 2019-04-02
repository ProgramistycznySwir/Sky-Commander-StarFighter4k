using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Control : MonoBehaviour
{
    [Header("Barrel ends:")]
    public Transform[] barrelEnds;

    [Header("Projectile:")]
    public GameObject projectile;
    public float projectileSpeed;
    public float range;
    public float damage;
    public int matterialisationDelay;

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

    [SerializeField]
    public Vector3 target;

    bool firingThisFrame = false;

    // Start is called before the first frame update
    void Start()
    {
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

        Vector2 direction = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        transform.up = direction;

        if (!firingThisFrame)
        {
            reloadVAR -= reloadRate * Time.deltaTime; //if lmb is not pushed reloading is twice faster
            firingThisFrame = false;
        }
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
                newProjectile.GetComponent<MarchingBullet>().SetStats(projectileSpeed, range, damage, matterialisationDelay);
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
