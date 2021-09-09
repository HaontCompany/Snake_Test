using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAll : MonoBehaviour
{
    public float z;
    void Start()
    {
        if(z == 0)
        z = 4;
    }
    void FixedUpdate()
    {
        transform.Rotate(0,0,z);
    }
}
