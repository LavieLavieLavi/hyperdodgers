using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    int starCount = 500;
    public Star star;

    void Start()
    {
        for (int i = 0; i < starCount; i++)
        {
            Instantiate(star, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
