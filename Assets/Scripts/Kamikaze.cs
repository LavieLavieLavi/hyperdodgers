using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    float width;
    float height;

    float speed = 14;

    Vector3 moveDirection;

    float timeSinceSpawn;

    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

        // random spawn position
        float padding = 2;
        switch (Random.Range(0, 3))
        {
            // left
            case 0: transform.position = new Vector2(-width - 2, Random.Range(-height, height)); break;
            
            // right
            case 1: transform.position = new Vector2(width + 2, Random.Range(-height, height)); break;
            
            // top
            case 2: transform.position = new Vector2(Random.Range(-width, width), height + 2); break;

            // hindi magsspawn sa bottom kasi that would be annoying
        }

        Vector3 playerPosition =  GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 relativePosition = playerPosition - transform.position;
        moveDirection = relativePosition.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn > 5)
        {
            Destroy(this.gameObject);
        }
    }
}
