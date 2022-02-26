using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float smoothing = 0.05F;
    float timeSinceSpawn;

    SpriteRenderer spriteRenderer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(
            255, 255, 255,
            Mathf.Lerp(spriteRenderer.color.a, 0, 1 - Mathf.Pow(smoothing, Time.deltaTime))
        );

        if (timeSinceSpawn > 1)
        {
            Destroy(this.gameObject);
        }
    }
}
