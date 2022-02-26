using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battleship : MonoBehaviour
{
    float duration = 7.5F; // amount of time in screen before disappearing 
    float timeLeft;

    float shootInterval = 3F;
    float shootTimeLeft;

    float width;
    float height;

    float smoothing = 0.1F;

    int bulletsPerShot = 10;
    float bulletSpread= 90 * Mathf.Deg2Rad;
    float bulletDirectionDifference;

    Vector2 desiredPosition;
    Vector3 bulletSpawnPosition;

    public Bullet bullet;

    void Start()
    {
        timeLeft = duration;
        shootTimeLeft = shootInterval;

        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

        bulletDirectionDifference = bulletSpread / bulletsPerShot;

        transform.position = new Vector2(
            Random.Range(-width, width),
            height + 2
        );

        desiredPosition = new Vector2(
            Random.Range(-width, width),
            Random.Range(height, 0)
        );

        bulletSpawnPosition = new Vector2(0, -0.5F);
    }
    
    void Shoot()
    {
        for (int i = 0; i <= bulletsPerShot; i++)
        {
            float t = (float)i / bulletsPerShot;

            Debug.Log(t);

            float directionPolar = Mathf.Lerp(0F, bulletSpread, t) - ((90 * Mathf.Deg2Rad) + (bulletSpread/2F));
            bullet.direction = new Vector2(
                Mathf.Cos(directionPolar),
                Mathf.Sin(directionPolar)
            );

            bullet.transform.rotation = Quaternion.Euler(0, 0, directionPolar * Mathf.Deg2Rad);

            Instantiate(bullet, bulletSpawnPosition + transform.position, new Quaternion());
        }
    }

    // Update is called once per frame
    void Update()
    {
        // go to desired position
        transform.position = Vector2.Lerp(transform.position, desiredPosition, 1 - Mathf.Pow(smoothing, Time.deltaTime));

        shootTimeLeft -= Time.deltaTime;
        if (shootTimeLeft < 0)
        {
            Shoot();
            shootTimeLeft = shootInterval;
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
