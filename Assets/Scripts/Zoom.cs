using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float zoom = 5;
    void Update()
    {       
         GetComponent<Camera>().orthographicSize +=0.1f*Time.deltaTime;       
    }
}
