using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Settings:")]
    public float damage;
    public int materialisationDelay = 1;
    

    void Start()
    {
        Invoke("Materialise", materialisationDelay * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Stats _stats;
        if (_stats = collider.GetComponentInParent<Stats>())
        {
            _stats.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    void Materialise()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
