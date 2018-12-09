using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Settings:")]
    public float damage = 3f;
    public int materialisationDelay = 1;
    

    void Start()
    {
        Invoke("Materialise", materialisationDelay * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Done shit");
        if (collider.GetComponent<Stats>() != null)
        {
            collider.GetComponent<Stats>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    void Materialise()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
