using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Stats:")]
    public float health;
    public float maxHealth;
    public float maxVelocity;

    [Header("Sockets:")]
    public GameObject deathAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(0 > health)
        {
            Die();
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }
    public void Die()
    {
        //Instantiate<GameObject>(deathAnimation, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
