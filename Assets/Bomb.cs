using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float degrees;
    float rotationSpeed;
    int rotationDirection;

    Vector3 moveDirectionVector;
    float moveSpeed;

    float width;
    float height;

    GameObject[] gameObjects;

    public Explosion explosion;

    // Start is called before the first frame update
    void Start()
    {
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

        // spawn from up or down?
        float padding = 2;
        if (moveDirectionVector.y > 0)
        {
            transform.position = new Vector2(-height - padding, Random.Range(-width, width));
        }
        else
        {
            transform.position = new Vector2(height + padding, Random.Range(-width, width));
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            gameObjects = GameObject.FindGameObjectsWithTag("Bullet");
            for (var i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }

            Instantiate(explosion);
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


        if (transform.position.x > width * 2 || transform.position.y > height * 2 || transform.position.x < -width * 2 || transform.position.y < -height * 2)
        {
            Destroy(this.gameObject);
        }
    }
}
