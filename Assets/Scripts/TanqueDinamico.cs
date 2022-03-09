using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanqueDinamico : MonoBehaviour
{
    public Valve valveIn, valveOut;
    public float h, A, dhDt;
    public Transform liquid;
    Trend trend;
    float lastTime;

    public float maxHeight;
    private void Start() {
        A = GetComponent<TankEscalable>().diametro*3.14f;
        maxHeight = GetComponent<TankEscalable>().alturaTank;
        trend = GetComponentInChildren<Trend>();
        InvokeRepeating(nameof(LogTrend),1,0.5f);
    }
    
    private void FixedUpdate() {
        CalculateNextStep();
    }

    void LogTrend()
    {
        trend.LogTrend(h*0.4f,Time.fixedDeltaTime);
    }

    void CalculateNextStep()
    {
        float q1 = valveIn.actualFlow;

        valveOut.actualFlow = valveOut.apertura*valveOut.kv*Mathf.Sqrt(h);
        float q2 = valveOut.actualFlow;

        dhDt = (q1-q2)/A;
        h = h + dhDt;

        if(h<0) h = 0;
        if(h>maxHeight) h = maxHeight;

        liquid.localScale = new Vector3(1,h,1);
        lastTime = Time.time;
    }
}
