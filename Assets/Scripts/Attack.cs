using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage = 3f;
    public int materialisationDelay = 1;


    void Start()
    {
        Invoke("Materialise", materialisationDelay * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Stats>() != null)
        {
            collision.collider.GetComponent<Stats>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    void Materialise()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
