using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool Horizontal;
    public float RotatingSpeed; 

    // Update is called once per frame
    void Update()
    {
        if (Horizontal) {
            transform.Rotate(new Vector3(0f, RotatingSpeed, 0f) * Time.deltaTime);
        }
        else {
            transform.Rotate(new Vector3(0f, 0f, RotatingSpeed) * Time.deltaTime);
        }
    }
}
