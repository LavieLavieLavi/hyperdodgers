using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    float speed = -3F;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector2(
            transform.position.x,
            transform.position.y + speed * Time.deltaTime
        );
    }
}
