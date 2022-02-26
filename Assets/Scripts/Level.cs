using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public float width;
    public float height;

    //Enemies
    const float asteroidSpawnInterval = 2; // every N seconds, an asteroid will spawn
    public float asteroidSpawnTimeLeft;

    const float strikerSpawnInterval = 3; // every N seconds, a striker will spawn
    public float strikerSpawnTimeLeft;

    const float battleshipSpawnInterval = 5; // every N seconds, a battleship will spawn
    public float battleshipSpawnTimeLeft;

    const float kamikazeSpawnInterval = 2; // every N seconds, a kamikaze will spawn
    public float kamikazeSpawnTimeLeft;

    public Asteroid asteroid;
    public Striker striker;
    public Battleship battleship;
    public Kamikaze kamikaze;

    //Powerups
    const float bombSpawnInterval = 3; // every N seconds, a bomb will spawn
    public float bombSpawnTimeLeft;

    const float InvSpawnInterval = 3; // every N seconds, a striker will spawn
    public float InvSpawnTimeLeft;

    public Bomb bomb;
    public Invincible invincible;

    public float timeSinceStart;
    float difficultyInterval = 10;

    int currentScene;

    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

        asteroidSpawnTimeLeft = asteroidSpawnInterval;
        strikerSpawnTimeLeft = strikerSpawnInterval;
        battleshipSpawnTimeLeft = battleshipSpawnInterval;
        kamikazeSpawnTimeLeft = kamikazeSpawnInterval;

        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

        //Enemies
        if (asteroidSpawnTimeLeft < 0 && timeSinceStart > difficultyInterval * 0)
        {
            Instantiate(asteroid);
            asteroidSpawnTimeLeft = asteroidSpawnInterval;
        }

        if (strikerSpawnTimeLeft < 0 && timeSinceStart > difficultyInterval * 1)
        {
            Instantiate(striker);
            strikerSpawnTimeLeft = strikerSpawnInterval;
        }

        if (battleshipSpawnTimeLeft < 0 && timeSinceStart > difficultyInterval * 2)
        {
            Instantiate(battleship);
            battleshipSpawnTimeLeft = battleshipSpawnInterval;
        }

        if (kamikazeSpawnTimeLeft < 0 && timeSinceStart > difficultyInterval * 0)
        {
            Instantiate(kamikaze);
            kamikazeSpawnTimeLeft = kamikazeSpawnInterval;
        }

        asteroidSpawnTimeLeft -= Time.deltaTime;
        strikerSpawnTimeLeft -= Time.deltaTime;
        battleshipSpawnTimeLeft -= Time.deltaTime;
        kamikazeSpawnTimeLeft -= Time.deltaTime;

        //Powerups
        if (bombSpawnTimeLeft < 0 && timeSinceStart > difficultyInterval * 3)
        {
            Instantiate(bomb);
            bombSpawnTimeLeft = bombSpawnInterval;
        }

        if (InvSpawnTimeLeft < 0 && timeSinceStart > difficultyInterval * 2)
        {
            Instantiate(invincible);
            InvSpawnTimeLeft = InvSpawnInterval;
        }

        bombSpawnTimeLeft -= Time.deltaTime;
        InvSpawnTimeLeft -= Time.deltaTime;

        if (currentScene == 2) // main game scene
        {
            timeSinceStart += Time.deltaTime;
        }
    }
}
