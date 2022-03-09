using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimerOrden : MonoBehaviour
{
    public Trend trend1;
    public float q1, q2;
    public float h1, dh1;
    public float A, cv;

    private void Start() {
        InvokeRepeating("Log",0,0.1f);
    }
    void FixedUpdate()
    {
        q2 = cv*Mathf.Sqrt(h1);
        dh1 = (q1-q2)/A;
        h1 = h1 + dh1;
    }

    void Log()
    {
        trend1.LogTrend(h1,0.02f);
    }
}
