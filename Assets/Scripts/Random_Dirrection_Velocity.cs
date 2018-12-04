using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Dirrection_Velocity : MonoBehaviour
{
    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-velocity.x, velocity.x), Random.Range(-velocity.y, velocity.y));
    }
    
}
