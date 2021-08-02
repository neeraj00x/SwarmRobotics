using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class move : MonoBehaviour
{
    public Vector3 rot;

    public Transform tr;
    Time Time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per timeunit
    void FixedUpdate()
    {
        
        //tr.Rotate(rot, 1000);
        float x = 32 * Mathf.Sin(Time.realtimeSinceStartup) * Mathf.Sin(Time.realtimeSinceStartup) * Mathf.Sin(Time.realtimeSinceStartup);
        float z = 26 * Mathf.Cos(Time.realtimeSinceStartup) - 10* Mathf.Cos(2*Time.realtimeSinceStartup) - 4* Mathf.Cos(3*Time.realtimeSinceStartup) - 2*Mathf.Cos(4*Time.realtimeSinceStartup);
        tr.position = new Vector3(x, 5, z);
      
    }
}
