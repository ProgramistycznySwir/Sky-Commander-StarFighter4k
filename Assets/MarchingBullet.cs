using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingBullet : MonoBehaviour
{
    public float velocity;
    public int matterialisationDelay;
    public MarchingAttack marchingAttack;

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, velocity * Time.fixedDeltaTime);
        if (hit && matterialisationDelay <= 0)
        {
            Stats _stats;
            if (_stats = hit.collider.GetComponentInParent<Stats>())
            {
                Hit(_stats);
            }
            Destroy(gameObject);
        }
        else transform.Translate(0, velocity * Time.fixedDeltaTime, 0);
        matterialisationDelay--;
    }
    private void Hit(Stats _stats)
    {
        //Debug.Log("Bamboozled!!!");
        Debug.Log("I'm here");
        marchingAttack.DealDamage(_stats);        
    }
}
