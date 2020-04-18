using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * 30.0f);   
    }
}
