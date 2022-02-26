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

    const float battleshipSpawnInterval = 5; // every N seconds, a striker will spawn
    public float battleshipSpawnTimeLeft;

    public Asteroid asteroid;
    public Striker striker;
    public Battleship battleship;

    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

        asteroidSpawnTimeLeft = asteroidSpawnInterval;
        strikerSpawnTimeLeft = strikerSpawnInterval;
        battleshipSpawnTimeLeft = battleshipSpawnInterval;
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

        if (battleshipSpawnTimeLeft < 0)
        {
            Instantiate(battleship);
            battleshipSpawnTimeLeft = battleshipSpawnInterval;
        }

        asteroidSpawnTimeLeft -= Time.deltaTime;
        strikerSpawnTimeLeft -= Time.deltaTime;
        battleshipSpawnTimeLeft -= Time.deltaTime;
    }
}
