using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RoboMovement : MonoBehaviour
{
    private Transform GuideTrans;
    private NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GuideTrans = GameObject.Find("Guide").transform;
        nav = GameObject.Find("Robo").GetComponent<NavMeshAgent>();
        nav.SetDestination(GuideTrans.position);

        GuideTrans = GameObject.Find("Guide1").transform;
        nav = GameObject.Find("Robo1").GetComponent<NavMeshAgent>();
        nav.SetDestination(GuideTrans.position);

        GuideTrans = GameObject.Find("Guide2").transform;
        nav = GameObject.Find("Robo2").GetComponent<NavMeshAgent>();
        nav.SetDestination(GuideTrans.position);

        GuideTrans = GameObject.Find("Guide3").transform;
        nav = GameObject.Find("Robo3").GetComponent<NavMeshAgent>();
        nav.SetDestination(GuideTrans.position);

        GuideTrans = GameObject.Find("Guide4").transform;
        nav = GameObject.Find("Robo4").GetComponent<NavMeshAgent>();
        nav.SetDestination(GuideTrans.position);

        GuideTrans = GameObject.Find("Guide4").transform;
        nav = GameObject.Find("Robo5").GetComponent<NavMeshAgent>();
        nav.SetDestination(GuideTrans.position);

    }
}
