using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentControl : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public Transform hitPoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                hitPoint.position = hit.point;
                agent.SetDestination(hit.point);
                //Debug.DrawRay(cam.transform.position, cam.transform.position - hit.point);
            }
        }
    }
}
