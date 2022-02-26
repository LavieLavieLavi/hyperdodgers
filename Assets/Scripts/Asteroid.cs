using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : BaseBullet
{
    float degrees;
    float rotationSpeed;
    int rotationDirection;

    Vector3 moveDirectionVector;
    private Vector2 screenBounds;
    float moveSpeed;

    public PlayerShip player;

    float width;
    float height;

    void Start()
    {
        damage = 10;
        degrees = Random.Range(0F, 360F);
        rotationSpeed = Random.Range(50F, 200F);
        moveSpeed = Random.Range(2.5F, 10F);

        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

        // rotate CC or CCW?
        switch (Random.Range(0, 2))
        {
            case 0: rotationDirection = -1; break; // CC
            case 1: rotationDirection = 1; break;  // CCW
        }


        float moveDirection = Random.Range(0, 360 * Mathf.Deg2Rad);
        moveDirectionVector = new Vector2(
            Mathf.Cos(moveDirection),
            Mathf.Sin(moveDirection)
        );

        // spawn from left or right?
        if (moveDirectionVector.x > 0)
        {
            transform.position = new Vector2(-width, Random.Range(-height, height));
        }
        else
        {
            transform.position = new Vector2(width, Random.Range(-height, height));
        }
    }

    // Update is called once per frame
    void Update()
    {
        // move
        transform.position += moveDirectionVector * moveSpeed * Time.deltaTime;

        // rotate
        degrees += rotationSpeed * rotationDirection * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, degrees);


        // destroyed if ofscreen
        if (transform.position.x > width*2 || transform.position.y > height * 2 || transform.position.x < -width * 2 || transform.position.y < -height * 2)
        {
            Destroy(this.gameObject);
        }

    }
}
