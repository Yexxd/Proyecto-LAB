using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePlanta : MonoBehaviour
{
    public float ht = 0, dhDt =0;
    public float q1 = 0, k2, q2, A = 1;
    public float litros = 0;

    public Transform liquid;
    private void Start() {
        //InvokeRepeating(nameof(CalculateDerivate),0,0.1f);
    }

    private void FixedUpdate() {
        //GetComponentInChildren<Trend>().exampleValue = 10-2*ht;
        q2 = k2*0.0125f*Mathf.Sqrt(ht);
        ht += dhDt*10;
        dhDt = (q1 - q2)/A;


        if(ht<0) ht = 0;
        if(ht>50) ht = 50;
        liquid.localScale = new Vector3(1,ht,1);
    }
}
