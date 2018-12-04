using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelCreation : MonoBehaviour
{
    [Header("Map size:")]
    public Vector2 mapSize;


    [Header("Clusters Settings:")]
    public int numberOfClusters;
    public Vector2 clustersSize;
    public float clusterSizeMaxAbnormality;
    public GameObject asteroidClusterMinimapSprite;

    [Header("Asteroids Settings:")]
    public GameObject[] asteroids;
    public Vector2Int numberOfAsteroidsInCluster;
    public Vector2 asteroidsSize;
    public float asteroidsSizeMaxAbnormality, colorMaxAbnormality;

    // Start is called before the first frame update
    void Start()
    {
        int a = 0;
        int b = 0;
        while (a < numberOfClusters)
        {
            Vector2 centerOfCluster = new Vector2(Random.Range(-mapSize.x / 2, mapSize.y / 2), Random.Range(-mapSize.x / 2, mapSize.y / 2));
            int numberOfAsteroidsInThisCluster = Random.Range(numberOfAsteroidsInCluster.x, numberOfAsteroidsInCluster.y);
            float clusterSizeVAR = Random.Range(clustersSize.x, clustersSize.y);
            Vector2 realClusterSize = new Vector2(clusterSizeVAR + Random.Range(-clusterSizeMaxAbnormality, clusterSizeMaxAbnormality), clusterSizeVAR + Random.Range(-clusterSizeMaxAbnormality, clusterSizeMaxAbnormality));
            Instantiate<GameObject>(asteroidClusterMinimapSprite, new Vector3(centerOfCluster.x, centerOfCluster.y, 0), new Quaternion(0,0,0,0));
            while (b < numberOfAsteroidsInThisCluster)
            {
                int whichAsteroid = Random.Range(0, asteroids.Length);
                Vector3 asteroidPosition = new Vector3(centerOfCluster.x+Random.Range(-realClusterSize.x / 2, realClusterSize.x / 2), centerOfCluster.y+Random.Range(-realClusterSize.y / 2, realClusterSize.y / 2), 0);
                Quaternion asteroidRotation = new Quaternion(0, 0, Random.Range(-3, 3), 1);
                float asteroidSizeVAR = Random.Range(asteroidsSize.x, asteroidsSize.y);
                Vector3 asteroidSize = new Vector3(asteroidSizeVAR + Random.Range(-asteroidsSizeMaxAbnormality, asteroidsSizeMaxAbnormality), asteroidSizeVAR + Random.Range(-asteroidsSizeMaxAbnormality, asteroidsSizeMaxAbnormality), 1);
                GameObject newAsteroid = Instantiate<GameObject>(asteroids[whichAsteroid], asteroidPosition, asteroidRotation);
                newAsteroid.transform.localScale = asteroidSize;
                b++;
            }
            b = 0;
            a++;
        }        
    }
}
