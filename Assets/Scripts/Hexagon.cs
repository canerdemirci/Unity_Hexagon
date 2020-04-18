using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    public float shrinkSpeed = 3.0f;

    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.rotation = Random.Range(0.0f, 360.0f);    
        transform.localScale = Vector3.one * 10.0f;
    }

    void Update()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if (transform.localScale.x <= 0.05f)
        {
            Destroy(gameObject);
        }
    }
}
