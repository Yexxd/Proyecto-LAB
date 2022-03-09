using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegundoOrden : MonoBehaviour
{
    public Trend trend1, trend2;

    public float qi, q1, q2;
    public float h1,h2, dh1, dh2;

    public float A1, A2, cv1, cv2;
    // Update is called once per frame

    private void Start() {
        InvokeRepeating("Log",0,0.1f);
    }
    void FixedUpdate()
    {
        q1 = cv1*Mathf.Sqrt(h1);
        q2 = cv2*Mathf.Sqrt(h2);
        dh1 = (qi-q1)/A1;
        dh2 = (q1-q2)/A2;
        h1 += dh1;
        h2 += dh2;
    }

    void Log()
    {
        trend1.LogTrend(h1,0.02f);
        trend2.LogTrend(h2,0.02f);
    }

}   
