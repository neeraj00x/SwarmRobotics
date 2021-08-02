using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideMovement : MonoBehaviour
{
    float time = 0, speed;


    void Start()
    {
        speed = 1.0f;
    }


    void Update()
    {
        time = time + Time.deltaTime * speed;
    }
    void FixedUpdate()
    {
        GuidePath("Guide", 0.5f, 75, 75);
        GuidePath("Guide1", 0.6f, 100, 100);
        GuidePath("Guide2", 0.7f, 135, 135);
        GuidePath("Guide3", 0.7f, 165, 165);
        GuidePath("Guide4", 0.7f, 200, 200);

    }

    private void GuidePath(string Guide, float speedFactor, float l, float b)
    {
        float x, y, z;
        x = Mathf.Cos(speedFactor*time) * b;
        y = 7;
        z = Mathf.Sin(speedFactor * time) * l;
        Transform P = GameObject.Find(Guide).transform;
        P.position = new Vector3(x, y, z);
    }
    

}

