using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Camera_Movement : MonoBehaviour
{
    public enum proggresiveScroolSensitivity { none, _1_25, _1_6, _1_5625, _2, _2_5, _3_125, _4, _5, _6_25, _10, _20, _50}; //0,8; 0,625; 0,64; 0,5; 0,4; 0,32; 0,25; 0,2; 0,16; 0,1; 0,05, 0,02

    [Header("Settings:")]
    private float z;
    public bool scrool = false;
    public proggresiveScroolSensitivity progressiveScrool = proggresiveScroolSensitivity.none;
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
        if (scrool)
        {
            // gameObject.GetComponent<Camera>().orthographicSize -= 2 * Input.GetAxis("Mouse ScrollWheel") * gameObject.GetComponent<Camera>().orthographicSize;
            gameObject.GetComponent<PixelPerfectCamera>().assetsPPU += (int)(2 * Input.GetAxis("Mouse ScrollWheel") * gameObject.GetComponent<PixelPerfectCamera>().assetsPPU);
            var camera = new UnityEngine.Experimental.Rendering.Universal.PixelPerfectCamera();
            // camera.assetsPPU
            //gameObject.GetComponent<Camera>().orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
        }
    }
}
