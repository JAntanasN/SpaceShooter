using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int numberOfAsteroids = 50;
    public Vector3 spawnBoundary = new Vector3(32f, 2f, 32f);


    void Start()
    {
        SpawnAsteroids();
    }


    void SpawnAsteroids()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnBoundary.x, spawnBoundary.x),
                Random.Range(-spawnBoundary.y, spawnBoundary.y),
                Random.Range(-spawnBoundary.z, spawnBoundary.z)
            );
            Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);
        }
    }


}
