using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform objectToFollow;
    private float z;
    public bool scrool = false;


    void Start()
    {
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y, z);
        if(scrool) gameObject.GetComponent<Camera>().orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
    }
}
