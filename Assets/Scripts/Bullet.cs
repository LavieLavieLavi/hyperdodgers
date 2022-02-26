using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    float speed = -5F;

    float width;
    float height;

    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }

    void Update()
    {
        transform.position = new Vector2(
            transform.position.x,
            transform.position.y + speed * Time.deltaTime
        );

        // destroyed if ofscreen
        if (transform.position.x > width*2 || transform.position.y > height * 2 || transform.position.x < -width * 2 || transform.position.y < -height * 2)
        {
            Destroy(this.gameObject);
        }
    }
}
