using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    // Start is called before the first frame update
    float timeSinceSpawn;
    SpriteRenderer spriteRenderer;

    float smoothing = 0.00005F;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(
            transform.localScale.x + Time.deltaTime * 7,
            transform.localScale.y + Time.deltaTime * 7
        );        

        timeSinceSpawn += Time.deltaTime;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(
            0, 255, 255,
            Mathf.Lerp(spriteRenderer.color.a, 0, 1 - Mathf.Pow(smoothing, Time.deltaTime))
        );

        if (timeSinceSpawn > 1)
        {
            Destroy(this.gameObject);
        }
    }
}
