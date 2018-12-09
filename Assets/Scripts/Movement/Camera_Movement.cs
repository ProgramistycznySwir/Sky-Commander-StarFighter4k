using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    [Header("Settings:")]
    [SerializeField]
    private float z;
    public bool scrool = false;
    public float sensitivity = 1f;
    [Header("Sockets:")]
    public Transform objectToFollow;
    


    void Start()
    {
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(objectToFollow != null)
        {
            transform.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y, z);
        }        
        if(scrool) gameObject.GetComponent<Camera>().orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
    }
}
