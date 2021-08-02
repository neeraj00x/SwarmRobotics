using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pso_search : MonoBehaviour
{
    public Transform robo1_pose, robo2_pose, robo3_pose, robo4_pose, robo5_pose, robo6_pose, goal, actual_goal, ob1, ob2, ob3, ob4, ob5;

    Vector3 p1best = Vector3.positiveInfinity;
    Vector3 p2best = Vector3.positiveInfinity;
    Vector3 p3best = Vector3.positiveInfinity;
    Vector3 p4best = Vector3.positiveInfinity;
    Vector3 p5best = Vector3.positiveInfinity;
    Vector3 p6best = Vector3.positiveInfinity;

    float p1best_val = 1000f, p2best_val = 1000f, p3best_val = 1000f, p4best_val = 1000f, p5best_val = 1000f, p6best_val = 1000f;

    float w = 0.8f, c1 = 2.0f, c2 = 2f;

    float a1 = 0f, a2 = 0f, a3 = 0f, a4 = 0f, a5 = 0f, a6 = 0f;

    float alpha = 0.0004f, alpha1 = 0.1f;

    public GameObject target;
    public Text txt;
    Vector3 v1 = Vector3.zero, v2 = Vector3.zero, v3 = Vector3.zero, v4 = Vector3.zero, v5 = Vector3.zero, v6 = Vector3.zero;

    //Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 g = goal.position;
        Vector3 d1g = goal.position - robo1_pose.position;
        Vector3 d2g = goal.position - robo2_pose.position;
        Vector3 d3g = goal.position - robo3_pose.position;
        Vector3 d4g = goal.position - robo4_pose.position;
        Vector3 d5g = goal.position - robo5_pose.position;
        Vector3 d6g = goal.position - robo6_pose.position;

        Vector3 d1ag = actual_goal.position - robo1_pose.position;
        Vector3 d2ag = actual_goal.position - robo2_pose.position;
        Vector3 d3ag = actual_goal.position - robo3_pose.position;
        Vector3 d4ag = actual_goal.position - robo4_pose.position;
        Vector3 d5ag = actual_goal.position - robo5_pose.position;
        Vector3 d6ag = actual_goal.position - robo6_pose.position;

        Vector3 d11 = robo2_pose.position - robo1_pose.position;
        Vector3 d12 = robo3_pose.position - robo1_pose.position;
        Vector3 d13 = robo4_pose.position - robo1_pose.position;
        Vector3 d14 = robo5_pose.position - robo1_pose.position;
        Vector3 d15 = robo6_pose.position - robo1_pose.position;


        Vector3 d101 = ob1.position - robo1_pose.position;
        Vector3 d102 = ob2.position - robo1_pose.position;
        Vector3 d103 = ob3.position - robo1_pose.position;
        Vector3 d104 = ob4.position - robo1_pose.position;
        Vector3 d105 = ob5.position - robo1_pose.position;

        Vector3 d21 = robo1_pose.position - robo2_pose.position;
        Vector3 d22 = robo3_pose.position - robo2_pose.position;
        Vector3 d23 = robo4_pose.position - robo2_pose.position;
        Vector3 d24 = robo5_pose.position - robo2_pose.position;
        Vector3 d25 = robo6_pose.position - robo2_pose.position;

        Vector3 d201 = ob1.position - robo2_pose.position;
        Vector3 d202 = ob2.position - robo2_pose.position;
        Vector3 d203 = ob3.position - robo2_pose.position;
        Vector3 d204 = ob4.position - robo2_pose.position;
        Vector3 d205 = ob5.position - robo2_pose.position;

        Vector3 d31 = robo1_pose.position - robo3_pose.position;
        Vector3 d32 = robo2_pose.position - robo3_pose.position;
        Vector3 d33 = robo4_pose.position - robo3_pose.position;
        Vector3 d34 = robo5_pose.position - robo3_pose.position;
        Vector3 d35 = robo6_pose.position - robo3_pose.position;

        Vector3 d301 = ob1.position - robo3_pose.position;
        Vector3 d302 = ob2.position - robo3_pose.position;
        Vector3 d303 = ob3.position - robo3_pose.position;
        Vector3 d304 = ob4.position - robo3_pose.position;
        Vector3 d305 = ob5.position - robo1_pose.position;

        Vector3 d41 = robo1_pose.position - robo4_pose.position;
        Vector3 d42 = robo2_pose.position - robo4_pose.position;
        Vector3 d43 = robo3_pose.position - robo4_pose.position;
        Vector3 d44 = robo5_pose.position - robo4_pose.position;
        Vector3 d45 = robo6_pose.position - robo4_pose.position;

        Vector3 d401 = ob1.position - robo4_pose.position;
        Vector3 d402 = ob2.position - robo4_pose.position;
        Vector3 d403 = ob3.position - robo4_pose.position;
        Vector3 d404 = ob4.position - robo4_pose.position;
        Vector3 d405 = ob5.position - robo4_pose.position;

        Vector3 d51 = robo1_pose.position - robo5_pose.position;
        Vector3 d52 = robo2_pose.position - robo5_pose.position;
        Vector3 d53 = robo3_pose.position - robo5_pose.position;
        Vector3 d54 = robo4_pose.position - robo5_pose.position;
        Vector3 d55 = robo6_pose.position - robo5_pose.position;

        Vector3 d501 = ob1.position - robo5_pose.position;
        Vector3 d502 = ob2.position - robo5_pose.position;
        Vector3 d503 = ob3.position - robo5_pose.position;
        Vector3 d504 = ob4.position - robo5_pose.position;
        Vector3 d505 = ob5.position - robo5_pose.position;

        Vector3 d61 = robo1_pose.position - robo6_pose.position;
        Vector3 d62 = robo2_pose.position - robo6_pose.position;
        Vector3 d63 = robo3_pose.position - robo6_pose.position;
        Vector3 d64 = robo4_pose.position - robo6_pose.position;
        Vector3 d65 = robo5_pose.position - robo6_pose.position;

        Vector3 d601 = ob1.position - robo6_pose.position;
        Vector3 d602 = ob2.position - robo6_pose.position;
        Vector3 d603 = ob3.position - robo6_pose.position;
        Vector3 d604 = ob4.position - robo6_pose.position;
        Vector3 d605 = ob5.position - robo6_pose.position;

        Vector3 f1net = force(d11, d12, d13, d14, d15, d101, d102, d103, d104, d105);
        Vector3 f2net = force(d21, d22, d23, d24, d25, d201, d202, d203, d204, d205);
        Vector3 f3net = force(d31, d32, d33, d34, d35, d301, d302, d303, d304, d305);
        Vector3 f4net = force(d41, d42, d43, d44, d45, d401, d402, d403, d404, d405);
        Vector3 f5net = force(d51, d52, d53, d54, d55, d501, d502, d503, d504, d505);
        Vector3 f6net = force(d61, d62, d63, d64, d65, d601, d602, d603, d604, d605);

        if (d1ag.magnitude > 10 && d2ag.magnitude > 10 && d3ag.magnitude > 10 && d4ag.magnitude > 10 && d5ag.magnitude > 10 && d6ag.magnitude > 10)
        {
            p1best = find_pbest(d1g, p1best, p1best_val, g); p1best_val = find_pbestval(d1g, p1best_val);
            p2best = find_pbest(d2g, p2best, p2best_val, g); p2best_val = find_pbestval(d2g, p2best_val);
            p3best = find_pbest(d3g, p1best, p3best_val, g); p3best_val = find_pbestval(d3g, p3best_val);
            p4best = find_pbest(d4g, p1best, p4best_val, g); p4best_val = find_pbestval(d4g, p4best_val);
            p5best = find_pbest(d5g, p1best, p5best_val, g); p5best_val = find_pbestval(d5g, p5best_val);
            p6best = find_pbest(d6g, p1best, p6best_val, g); p6best_val = find_pbestval(d6g, p6best_val);

            Vector3 gbest = find_gbest(d1g, d2g, d3g, d4g, d5g, d6g, g);
            
            v1 = w * v1 + c1 * Random.value * (p1best - robo1_pose.position) + c2 * Random.value * (gbest - robo1_pose.position);
            robo1_pose.position += alpha * v1 + alpha1 * f1net;
            a1 += alpha * v1.magnitude;

            v2 = w * v2 + c1 * Random.value * (p2best - robo2_pose.position) + c2 * Random.value * (gbest - robo2_pose.position);
            robo2_pose.position += alpha * v2 + alpha1 * f2net;
            a2 += alpha * v2.magnitude;

            v3 = w * v3 + c1 * Random.value * (p3best - robo3_pose.position) + c2 * Random.value * (gbest - robo3_pose.position);
            robo3_pose.position += alpha * v3 + alpha1 * f3net;
            a3 += alpha * v3.magnitude;

            v4 = w * v4 + c1 * Random.value * (p4best - robo4_pose.position) + c2 * Random.value * (gbest - robo4_pose.position);
            robo4_pose.position += alpha * v4 + alpha1 * f4net;
            a4 += alpha * v4.magnitude;

            v5 = w * v5 + c1 * Random.value * (p5best - robo5_pose.position) + c2 * Random.value * (gbest - robo5_pose.position);
            robo5_pose.position += alpha * v5 + alpha1 * f5net;
            a5 += alpha * v5.magnitude;

            v6 = w * v6 + c1 * Random.value * (p6best - robo6_pose.position) + c2 * Random.value * (gbest - robo6_pose.position);
            robo6_pose.position += alpha * v6 + alpha1 * f6net;
            a6 += alpha * v6.magnitude; 
            
        }
        else
        {
            target.GetComponent<Renderer>().material.color = Color.green;
            txt.text = "Target Found!";
            txt.fontSize = 25;
            txt.fontStyle = FontStyle.Bold;
            txt.color = Color.blue;
            target.transform.localScale = new Vector3(15, 8, 15);
            Debug.Log(a1 + a2 + a3 + a4 + a5 + a6);
        }
    }
    static float find_pbestval(Vector3 d, float pbest_val)
    {
        float temp;
        if (d.magnitude < pbest_val)
        {
            temp = d.magnitude;
        }
        else temp = pbest_val;
        return temp;
    }
    static Vector3 find_pbest(Vector3 d, Vector3 d1, float pbest_val, Vector3 g)
    {
        Vector3 temp;
        if (d.magnitude < pbest_val)
        {
            temp = g - d;
        }
        else temp = d1;
        return temp;
    }
    static Vector3 find_gbest(Vector3 d1, Vector3 d2, Vector3 d3, Vector3 d4, Vector3 d5, Vector3 d6, Vector3 g)
    {
        Vector3 d = Vector3.zero;
        float temp = Mathf.Min(d1.magnitude, d2.magnitude, d3.magnitude, d4.magnitude, d5.magnitude, d6.magnitude);
        if (d1.magnitude == temp)
        { d = g - d1; }
        else if (d2.magnitude == temp)
        { d = g - d2; }
        else if (d3.magnitude == temp)
        { d = g - d3; }
        else if (d4.magnitude == temp)
        { d = g - d4; }
        else if (d5.magnitude == temp)
        { d = g - d5; }
        else if (d6.magnitude == temp)
        { d = g - d6; }
        return d;
    }
    static Vector3 force(Vector3 d1, Vector3 d2, Vector3 d3, Vector3 d4, Vector3 d5, Vector3 d6, Vector3 d7, Vector3 d8, Vector3 d9, Vector3 d10)
    {
        float a0 = 50f;
        float kr = 500f;
        Vector3 fnet, f1, f2, f3, f4, f5;
        f1 = kr * F(d1, a0);
        f2 = kr * F(d2, a0);
        f3 = kr * F(d3, a0);
        f4 = kr * F(d4, a0);
        f5 = kr * F(d5, a0);
        fnet = f1 + f2 + f3 + f4 + f5;
        return fnet;

        Vector3 F(Vector3 d, float threshold)
        {
            Vector3 f;
            if (d.magnitude <= threshold)
                f = (1 / d.sqrMagnitude) * (1 / d.magnitude - 1 / threshold) * (-d.normalized);
            else f = Vector3.zero;
            return f;
        }
    }
}