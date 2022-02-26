using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float width;
    public float height;

    const float asteroidSpawnInterval = 2; // every N seconds, an asteroid will spawn
    public float asteroidSpawnTimeLeft;

    const float strikerSpawnInterval = 3; // every N seconds, a striker will spawn
    public float strikerSpawnTimeLeft;

    public Asteroid asteroid;
    public Striker striker;

    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

        asteroidSpawnTimeLeft = asteroidSpawnInterval;
        strikerSpawnTimeLeft = strikerSpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (asteroidSpawnTimeLeft < 0)
        {
            Instantiate(asteroid);
            asteroidSpawnTimeLeft = asteroidSpawnInterval;
        }

        if (strikerSpawnTimeLeft < 0)
        {
            Instantiate(striker);
            strikerSpawnTimeLeft = strikerSpawnInterval;
        }

        asteroidSpawnTimeLeft -= Time.deltaTime;
<<<<<<< Updated upstream
        strikerSpawnTimeLeft -= Time.deltaTime;
=======

>>>>>>> Stashed changes
    }
}
