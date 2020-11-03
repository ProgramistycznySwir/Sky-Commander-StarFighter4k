using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int teamID;

    [Header("Stats:")]
    public Range hp = new Range(100f);
    public float maxVelocity;

    [Header("Sockets:")]
    public GameObject deathAnimation;

    // Update is called once per frame
    void Update()
    {
        if(0 > hp.value)
        {
            Die();
        }
    }

    public void TakeDamage(float dmg)
    {
        hp.value -= dmg;
    }
    public void Die()
    {
        //Instantiate<GameObject>(deathAnimation, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

[System.Serializable]
public struct Range
{
    public float value;
    public float max;

    public float Percent
    {
        get { return value / max; }
    }

    public Range(float max)
    {
        this.max = max;
        this.value = max;
    }
    public Range(float value, float max)
    {
        this.value = value;
        this.max = max;
    }
}
