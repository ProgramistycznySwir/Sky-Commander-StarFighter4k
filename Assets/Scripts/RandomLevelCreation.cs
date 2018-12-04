using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelCreation : MonoBehaviour
{
    public GameObject[] asteroids;
    public int numberOfAsteroids;
    public Vector2 mapSize;
    public Vector2 sizeOfAsteroids;
    public float sizeMaxAbnormality, colorMaxAbnormality;

    // Start is called before the first frame update
    void Start()
    {
        int a = 0;
        while (a < numberOfAsteroids)
        {
            int whichAsteroid = Random.Range(0, asteroids.Length);
            Vector3 asteroidPosition = new Vector3(Random.Range(-mapSize.x / 2, mapSize.x / 2), Random.Range(-mapSize.y / 2, mapSize.y / 2), 0);
            Quaternion asteroidRotation = new Quaternion(0, 0, Random.Range(-3, 3), 1);
            float asteroidSizeVAR = Random.Range(sizeOfAsteroids.x, sizeOfAsteroids.y);
            Vector3 asteroidSize = new Vector3(asteroidSizeVAR+Random.Range(-sizeMaxAbnormality, sizeMaxAbnormality), asteroidSizeVAR + Random.Range(-sizeMaxAbnormality, sizeMaxAbnormality), 1);
            GameObject newAsteroid = Instantiate<GameObject>(asteroids[whichAsteroid], asteroidPosition, asteroidRotation);
            newAsteroid.transform.localScale = asteroidSize;
            a++;
        }
    }
}
