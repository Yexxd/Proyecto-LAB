using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanquesSerie : MonoBehaviour
{
    public Trend trend1, trend2;
    public Transform liquido1, liquido2;

    public ParticleSystem partsq1, partsq2, partsqi;
     
    [Header("Parametros definibles")]
    public float qi;
    public float A1,A2,cv1,cv2, maxTk1, maxTk2;
    
    
    [Header("Variables")]
    public float q1;
    public float q2, h1,h2, dh1, dh2;
    private void Start() {
        InvokeRepeating("Log",0,0.2f);  
    }

    void FixedUpdate()
    {
        q1 = cv1*Mathf.Sqrt(h1);
        q2 = cv2*Mathf.Sqrt(h2);

        dh1 = (qi-q1)/A1;

        dh2 = (q1-q2)/A2;

        h1 = h1 + dh1;
        h2 = h2 + dh2;

        h1 = Limitar(h1,maxTk1);
        h2 = Limitar(h2,maxTk2);

        liquido1.localScale = new Vector3(1,h1,1);
        liquido2.localScale = new Vector3(1,h2,1);



        ParticleSystem.MainModule m = partsq1.main;
        ParticleSystem.EmissionModule me = partsq1.emission;
        m.startSpeed = q1/0.05f;
        me.rateOverTime = new ParticleSystem.MinMaxCurve(2000*Mathf.Log(1+q1));
        m = partsq2.main;
        me = partsq2.emission;
        m.startSpeed = q2/0.05f;
        me.rateOverTime = new ParticleSystem.MinMaxCurve(2000*Mathf.Log(1+q2));
        m = partsqi.main;
        me = partsqi.emission;
        m.startSpeed = qi/0.05f;
        me.rateOverTime = new ParticleSystem.MinMaxCurve(2000*Mathf.Log(1+qi));
    }

    void Log()
    {
        trend1.LogTrend(h1,0.02f);
        trend2.LogTrend(h2,0.02f);
    }

    public float Limitar(float variable, float max)
    {
        if(variable>max)
            return max;
        if(variable<0)
            return 0;
        else
            return variable;
    }
}   
