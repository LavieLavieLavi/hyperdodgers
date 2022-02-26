using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    Vector2 newPosition;
    float smoothing = 0.00005F; // lol

    const float minRotation = -22.5F;
    const float maxRotation = -minRotation;

    float health = 100; // temporary

    void Start()
    {
        transform.position = new Vector2(0, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision Detection");
    }

    void Update()
    {
        // used to calculate deltaX
        float previousPositionX = transform.position.x;

        // update position        
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.x = Mathf.Lerp(newPosition.x, mouseWorldPosition.x, 1 - Mathf.Pow(smoothing, Time.deltaTime)); // framerate independent lerp (very weird i know)
        newPosition.y = Mathf.Lerp(newPosition.y, mouseWorldPosition.y, 1 - Mathf.Pow(smoothing, Time.deltaTime)); // framerate independent lerp (very weird i know)
        transform.position = new Vector2(newPosition.x, newPosition.y);

        // update rotation
        float deltaX = (transform.position.x - previousPositionX)/Time.deltaTime; // change in x per SECOND (NOT per frame)
        transform.rotation = Quaternion.Euler(0, 0, 45 - Mathf.Clamp(deltaX, minRotation, maxRotation));
    }
}