using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfer : MonoBehaviour
{

    public Trend trend;
    
    private void Start() {
        for (float i = 0; i < 10; i+=0.1f)
        {
            float e2t = Mathf.Exp(-2*i);
            float y =  e2t* Mathf.Cos(i) - e2t*Mathf.Sin(i);
            trend.LogTrend(-y,0.01f);
        }
    }
}
