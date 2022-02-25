using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float width;
    public float height;

    const float asteroidSpawnInterval = 2; // every N seconds, an asteroid will spawn
    public float asteroidSpawnTimeLeft;
    
    public Asteroid asteroid;

    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

        asteroidSpawnTimeLeft = asteroidSpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (asteroidSpawnTimeLeft < 0)
        {
            Instantiate(asteroid);
            asteroidSpawnTimeLeft = asteroidSpawnInterval;
        }

        asteroidSpawnTimeLeft -= Time.deltaTime;
    }
}
