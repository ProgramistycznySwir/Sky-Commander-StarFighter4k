using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Diagnostics;
using System.Threading;

public class Cube_Coliders_Performance_Test : MonoBehaviour
{
    public int howManyAtFrame;
    public float inRange;
    public GameObject gameObject;
    public KeyCode holdToTest, testSphericalDetection;
    public int gameObjectCount;
    public float time;

    void Start()
    {
        UnityEngine.Debug.Log("<<<New Test>>>");
    }

    int cooldown;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(holdToTest))
        {
            UnityEngine.Debug.Log("Time of last frame:" + (Time.deltaTime * 1000f) + "ms");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            cooldown = howManyAtFrame;
            while(cooldown > 0)
            {
                Instantiate(gameObject, transform.position + new Vector3(UnityEngine.Random.Range(-inRange, inRange), UnityEngine.Random.Range(-inRange, inRange), UnityEngine.Random.Range(-inRange, inRange)), new Quaternion(0,0,0,0));
                gameObjectCount++;
                cooldown--;
            }
            stopWatch.Stop();
            UnityEngine.Debug.Log("Time spent on creating " + howManyAtFrame + " " + gameObject.name + ": " + stopWatch.ElapsedMilliseconds.ToString() + "ms (" + stopWatch.ElapsedTicks.ToString() + ")ticks");
        }
        if (Input.GetKeyDown(testSphericalDetection))
        {
            UnityEngine.Debug.Log("Time of last frame:" + (Time.deltaTime * 1000f) + "ms");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //long time1 = DateTime.Now.Ticks;
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, inRange * 1.73205f);
            int i = 0;
            while (i < hitColliders.Length)
            {
                //hitColliders[i].SendMessage("AddDamage");
                i++;
            }
            stopWatch.Stop();
            //long time2 = DateTime.Now.Ticks;
            UnityEngine.Debug.Log("Test time of " + gameObjectCount + " " + gameObject.name + ": " + stopWatch.ElapsedMilliseconds.ToString() + "ms (" + stopWatch.ElapsedTicks.ToString() + ")ticks");//(time2 - time1));
        }
    }
}
