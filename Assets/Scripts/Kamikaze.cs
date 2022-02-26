using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    float width;
    float height;

    float speed = 14;

    public Vector3 moveDirection;

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
            case 0: transform.position = new Vector2(-width - padding, Random.Range(-height, height)); break;
            
            // right
            case 1: transform.position = new Vector2(width + padding, Random.Range(-height, height)); break;
            
            // top
            case 2: transform.position = new Vector2(Random.Range(-width, width), height + padding); break;

            // hindi magsspawn sa bottom kasi that would be annoying
        }
        
        Vector3 targetPosition = GameObject.Find("Dodger").transform.position;
        if (targetPosition == null)
        {
            targetPosition = new Vector2(
                Random.Range(-width, width),
                Random.Range(-height, height)
            );
        }

        Vector2 relativePosition = targetPosition - transform.position;
        moveDirection = relativePosition.normalized;
        transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan(moveDirection.y/moveDirection.x) * Mathf.Rad2Deg) - 90);
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
