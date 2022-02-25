using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : BaseBullet
{
    float degrees;
    float rotationSpeed;
    int rotationDirection;
    
    Vector3 moveDirectionVector;
    float moveSpeed;

    void Start()
    {
        damage = 10;
        degrees = Random.Range(0F, 360F);
        rotationSpeed = Random.Range(50F, 200F);
        moveSpeed = Random.Range(2.5F, 10F);

        switch (Random.Range(0, 2))
        {
            case 0: rotationDirection = -1; break;
            case 1: rotationDirection = 1; break;
        }

        float moveDirection = Random.Range(0, 2 * 3.1415926F);
        moveDirectionVector = new Vector2(
            Mathf.Cos(moveDirection),
            Mathf.Sin(moveDirection)
        );
    }

    // Update is called once per frame
    void Update()
    {
        // move
        transform.position += moveDirectionVector * moveSpeed * Time.deltaTime;

        // rotate
        degrees += rotationSpeed * rotationDirection * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, degrees);
    }
}
