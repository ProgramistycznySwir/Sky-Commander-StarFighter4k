﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_AI : MonoBehaviour
{
    public Transform target;
    [Tooltip("(in degrees).")]
    public float deadZone = 5f;
    public bool doCourseCorrections;

    EngineControler engines;


    void Start()
    {
        engines = gameObject.GetComponent<EngineControler>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dirrection = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        //float dirrection = -((Mathf.Atan2(directionV2.x, directionV2.y) * 180) / Mathf.PI) - 90;
        //if (dirrection > 180) dirrection -= 360;
        //else if (dirrection < -180) dirrection += 360;
        //float courseChange = dirrection - transform.eulerAngles.z;
        //transform.eulerAngles = new Vector3(0, 0, -((Mathf.Atan2(forceDirrection.x, forceDirrection.y) * 180) / Mathf.PI) - 90);
        transform.up = dirrection.normalized;
        engines.Accelerate(1f);
        Debug.Log("dirrection: " + dirrection + " transform: " + transform.eulerAngles.z/* + " course change: " + courseChange*/);
    }

    public void GiveTarget(Transform target)
    {
        this.target = target;
    }
}
