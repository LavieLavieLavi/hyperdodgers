using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour
{
    Vector2 newPosition;
    float smoothing = 0.000025F; // lol

    const float minRotation = -30.0F;
    const float maxRotation = -minRotation;

    float health = 100; // temporary

    const float EffectTimer = 2; 
    public float Inv;

    bool protect;

    public BlinkEffect blinkEffect;
    const float blinkCooldown = 5;
    float blinkTimer;

    void Start()
    {
        transform.position = new Vector2(0, 0);
        Inv = EffectTimer;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (protect)
            {
                protect = false;
            }
            else
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene(0);
            }
         
        }

        if (col.gameObject.tag == "Invincibility")
        {
            protect = true;
            Debug.Log("Protected");
        }


    }

    void Update()
    {
        // used to calculate deltaX
        float previousPositionX = transform.position.x;

        // update position        
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // newPosition.x = Mathf.Lerp(newPosition.x, mouseWorldPosition.x, 1 - Mathf.Pow(smoothing, Time.deltaTime)); // framerate independent lerp (very weird i know)
        // newPosition.y = Mathf.Lerp(newPosition.y, mouseWorldPosition.y, 1 - Mathf.Pow(smoothing, Time.deltaTime)); // framerate independent lerp (very weird i know)
        transform.position = Vector2.Lerp(transform.position, mouseWorldPosition, 1 - Mathf.Pow(smoothing, Time.deltaTime));

        // update rotation
        float deltaX = (transform.position.x - previousPositionX)/Time.deltaTime; // change in x per SECOND (NOT per frame)
        transform.rotation = Quaternion.Euler(0, 0, -Mathf.Clamp(deltaX, minRotation, maxRotation));

        // shield 
        if (protect)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        // blink ability
        if (Input.GetMouseButtonDown(0) && blinkTimer < 0) // left click
        {
            Instantiate(blinkEffect, transform.position, new Quaternion());
            transform.position = mouseWorldPosition;
            blinkTimer = blinkCooldown;
        }

        blinkTimer -= Time.deltaTime;
        

    }
}
