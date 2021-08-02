using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APF : MonoBehaviour
{
    public Transform robo1_pose, robo2_pose, robo3_pose, robo4_pose, robo5_pose, robo6_pose;
    float alpha1 = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 r11 = robo2_pose.position - robo1_pose.position;
        Vector3 r12 = robo3_pose.position - robo1_pose.position; 
        Vector3 r13 = robo4_pose.position - robo1_pose.position;
        Vector3 r14 = robo5_pose.position - robo1_pose.position; 
        Vector3 r15 = robo6_pose.position - robo1_pose.position;

        Vector3 r21 = robo1_pose.position - robo2_pose.position; 
        Vector3 r22 = robo3_pose.position - robo2_pose.position;
        Vector3 r23 = robo4_pose.position - robo2_pose.position;
        Vector3 r24 = robo5_pose.position - robo2_pose.position; 
        Vector3 r25 = robo6_pose.position - robo2_pose.position;

        Vector3 r31 = robo1_pose.position - robo3_pose.position; 
        Vector3 r32 = robo2_pose.position - robo3_pose.position; 
        Vector3 r33 = robo4_pose.position - robo3_pose.position;
        Vector3 r34 = robo5_pose.position - robo3_pose.position;
        Vector3 r35 = robo6_pose.position - robo3_pose.position;

        Vector3 r41 = robo1_pose.position - robo4_pose.position; 
        Vector3 r42 = robo2_pose.position - robo4_pose.position; 
        Vector3 r43 = robo3_pose.position - robo4_pose.position;
        Vector3 r44 = robo5_pose.position - robo4_pose.position; 
        Vector3 r45 = robo6_pose.position - robo4_pose.position;

        Vector3 r51 = robo1_pose.position - robo5_pose.position; 
        Vector3 r52 = robo2_pose.position - robo5_pose.position; 
        Vector3 r53 = robo3_pose.position - robo5_pose.position;
        Vector3 r54 = robo4_pose.position - robo5_pose.position; 
        Vector3 r55 = robo6_pose.position - robo5_pose.position;

        Vector3 r61 = robo1_pose.position - robo6_pose.position; 
        Vector3 r62 = robo2_pose.position - robo6_pose.position; 
        Vector3 r63 = robo3_pose.position - robo6_pose.position;
        Vector3 r64 = robo4_pose.position - robo6_pose.position; 
        Vector3 r65 = robo5_pose.position - robo6_pose.position;

        Vector3 f1net = Repulsion(r11, r12, r13, r14, r15);
        Vector3 f2net = Repulsion(r21, r22, r23, r24, r25);
        Vector3 f3net = Repulsion(r31, r32, r33, r34, r35);
        Vector3 f4net = Repulsion(r41, r42, r43, r44, r45);
        Vector3 f5net = Repulsion(r51, r52, r53, r54, r55);
        Vector3 f6net = Repulsion(r61, r62, r63, r64, r65);

        robo1_pose.position += alpha1 * f1net;
        robo2_pose.position += alpha1 * f2net;
        robo3_pose.position += alpha1 * f3net;
        robo4_pose.position += alpha1 * f4net;
        robo5_pose.position += alpha1 * f5net;
        robo6_pose.position += alpha1 * f6net;
    }

    static Vector3 Repulsion(Vector3 d1, Vector3 d2, Vector3 d3, Vector3 d4, Vector3 d5)
    {
        float a0 = 100f; float kr1 = 500f;
        Vector3 fnet, f1, f2, f3, f4, f5;
        if (d1.magnitude <= a0)
            f1 = kr1 * (1 / d1.sqrMagnitude) * (1 / d1.magnitude - 1 / a0) * (-d1.normalized);
        else f1 = Vector3.zero;
        if (d2.magnitude <= a0)
            f2 = kr1 * (1 / d2.sqrMagnitude) * (1 / d2.magnitude - 1 / a0) * (-d2.normalized);
        else f2 = Vector3.zero;
        if (d3.magnitude <= a0)
            f3 = kr1 * (1 / d3.sqrMagnitude) * (1 / d3.magnitude - 1 / a0) * (-d3.normalized);
        else f3 = Vector3.zero;
        if (d4.magnitude <= a0)
            f4 = kr1 * (1 / d4.sqrMagnitude) * (1 / d4.magnitude - 1 / a0) * (-d4.normalized);
        else f4 = Vector3.zero;
        if (d5.magnitude <= a0)
            f5 = kr1 * (1 / d5.sqrMagnitude) * (1 / d5.magnitude - 1 / a0) * (-d5.normalized);
        else f5 = Vector3.zero;
        fnet = f1 + f2 + f3 + f4 + f5;
        return fnet;
    }
}
