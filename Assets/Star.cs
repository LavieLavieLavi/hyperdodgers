using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    const float speed = 3;

    Level level;

    float distanceFromCamera;
    float perceivedSpeed;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        // get width and height of visible area

        level = GetComponentInParent<Level>();

        transform.position = new Vector3(
            Random.Range(-level.width, level.width),
            Random.Range(-level.height, level.height),
            1
        );

        distanceFromCamera = Random.Range(1f, 5f);
        perceivedSpeed = speed/distanceFromCamera;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1/distanceFromCamera, 1/distanceFromCamera, 1/distanceFromCamera, 255);
    }

    void Update()
    {
        // update position
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y - (perceivedSpeed * Time.deltaTime),
            1
        );

        // wrap around
        if (transform.position.y < -level.height)
        {
            transform.position = new Vector3(
                transform.position.x,
                level.height,
                1
            );  
        }
    }
}
