using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float width;
    public float height;

    //Enemies
    const float asteroidSpawnInterval = 2; // every N seconds, an asteroid will spawn
    public float asteroidSpawnTimeLeft;

    const float strikerSpawnInterval = 3; // every N seconds, a striker will spawn
    public float strikerSpawnTimeLeft;

    const float battleshipSpawnInterval = 5; // every N seconds, a striker will spawn
    public float battleshipSpawnTimeLeft;

    public Asteroid asteroid;
    public Striker striker;
    public Battleship battleship;

    //Powerups
    const float bombSpawnInterval = 3; // every N seconds, a striker will spawn
    public float bombSpawnTimeLeft;

    const float InvSpawnInterval = 3; // every N seconds, a striker will spawn
    public float InvSpawnTimeLeft;

    public Bomb bomb;
    public Invincible invincible;

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

        //Enemies
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

        //Powerups
        if (bombSpawnTimeLeft < 0)
        {
            Instantiate(bomb);
            bombSpawnTimeLeft = bombSpawnInterval;
        }

        if (InvSpawnTimeLeft < 0)
        {
            Instantiate(invincible);
            InvSpawnTimeLeft = InvSpawnInterval;
        }

        bombSpawnTimeLeft -= Time.deltaTime;
        InvSpawnTimeLeft -= Time.deltaTime;
    }
}
