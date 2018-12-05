using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting_Script : MonoBehaviour
{
    public KeyCode fire;
    public GameObject target;
    public float projectileVelocity = 20f;
    public int numberOfTestsAtOnce;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(fire))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = MeetPointForProjectile2(transform.position, target.transform.position, target.GetComponent<Rigidbody2D>().velocity, projectileVelocity).normalized * projectileVelocity;
        }
    }
    /// <summary>
    /// Function that calculates point where turret have to shoot in order to hit target with given velocity
    /// </summary>
    /// <param name="A"> positionOfShooter</param>
    /// <param name="B"> targetPosition</param>
    /// <param name="tv"> targetVelocity</param>
    /// <param name="v"> projectileVelocity</param>
    /// <returns></returns>
    Vector2 MeetPointForProjectile(Vector2 A, Vector2 B, Vector2 tv, float v)
    {
        float x = (Mathf.Sqrt((B.y*B.y - 2*A.x*B.y + B.x*B.x - 2*A.x*B.x + A.y*A.y + A.x*A.x)*v*v + ((-B.x*B.x) + 2*A.x*B.x - A.x*A.x)*tv.y*tv.y + ((2*B.x - 2*A.x)*B.y - 2*A.y*B.x + 2*A.x*A.y)*tv.x*tv.y + ((-B.y*B.y) + 2*A.y*B.y - A.y*A.y)*tv.x*tv.x) + (B.y - A.x)*tv.y + (B.x - A.x)*tv.x)/(v*v - tv.y*tv.y - tv.x*tv.x);
        if(x < 0f)
        {
            x = (-Mathf.Sqrt((B.y * B.y - 2 * A.x * B.y + B.x * B.x - 2 * A.x * B.x + A.y * A.y + A.x * A.x) * v * v + ((-B.x * B.x) + 2 * A.x * B.x - A.x * A.x) * tv.y * tv.y + ((2 * B.x - 2 * A.x) * B.y - 2 * A.y * B.x + 2 * A.x * A.y) * tv.x * tv.y + ((-B.y * B.y) + 2 * A.y * B.y - A.y * A.y) * tv.x * tv.x) + (B.y - A.x) * tv.y + (B.x - A.x) * tv.x) / (v * v - tv.y * tv.y - tv.x * tv.x);
        }
        return B + tv * x;
    }
    /// <summary>
    /// Optimised MeetPointForProjectile function (Function that calculates point where turret have to shoot in order to hit target with given velocity); probably a bit less accurate
    /// </summary>
    /// <param name="A"> positionOfShooter</param>
    /// <param name="B"> targetPosition</param>
    /// <param name="tv"> targetVelocity</param>
    /// <param name="v"> projectileVelocity</param>
    /// <returns></returns>
    Vector2 MeetPointForProjectile2(Vector2 A, Vector2 B, Vector2 tv, float v)
    {
        float sqrt = Mathf.Sqrt((B.y * B.y - 2 * A.x * B.y + B.x * B.x - 2 * A.x * B.x + A.y * A.y + A.x * A.x) * v * v + ((-B.x * B.x) + 2 * A.x * B.x - A.x * A.x) * tv.y * tv.y + ((2 * B.x - 2 * A.x) * B.y - 2 * A.y * B.x + 2 * A.x * A.y) * tv.x * tv.y + ((-B.y * B.y) + 2 * A.y * B.y - A.y * A.y) * tv.x * tv.x);
        float addedAfterSqrt = (B.y - A.x) * tv.y + (B.x - A.x) * tv.x;
        float divider = (v * v - tv.y * tv.y - tv.x * tv.x);
        if (divider == 0)
        {
            return new Vector2(0,0);
        }
        float x = (sqrt + addedAfterSqrt) / divider;
        if (x < 0f)
        {
            x = (-sqrt + addedAfterSqrt) / divider;
        }
        return B + tv * x;
    }
    /// <summary>
    /// Even more optimised MeetPointForProjectile function (Function that calculates point where turret have to shoot in order to hit target with given velocity); probably a bit less accurate
    /// </summary>
    /// <param name="A"> positionOfShooter</param>
    /// <param name="B"> targetPosition</param>
    /// <param name="tv"> targetVelocity</param>
    /// <param name="v"> projectileVelocity</param>
    /// <returns></returns>
    Vector2 MeetPointForProjectile3(Vector2 A, Vector2 B, Vector2 tv, float v)
    {
        float sqrt = Mathf.Sqrt((B.y * B.y - 2 * A.x * B.y + B.x * B.x - 2 * A.x * B.x + A.y * A.y + A.x * A.x) * v * v + ((-B.x * B.x) + 2 * A.x * B.x - A.x * A.x) * tv.y * tv.y + ((2 * B.x - 2 * A.x) * B.y - 2 * A.y * B.x + 2 * A.x * A.y) * tv.x * tv.y + ((-B.y * B.y) + 2 * A.y * B.y - A.y * A.y) * tv.x * tv.x);
        float addedAfterSqrt = (B.y - A.x) * tv.y + (B.x - A.x) * tv.x;
        float divider = (v * v - tv.y * tv.y - tv.x * tv.x);
        float x = (sqrt + addedAfterSqrt) / divider;
        //if (x < 0f)
        //{
        //    x = (-sqrt + addedAfterSqrt) / divider;
        //}
        return B + tv * x;
    }
}
