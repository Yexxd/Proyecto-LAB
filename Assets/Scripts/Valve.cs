using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    public float actualFlow, maxFlow, kv;
    // Start is called before the first frame updat

    [Range(0,1)]
    public float apertura;

    ParticleSystem parts;
    // Update is called once per frame

    private void Start() {
        parts = GetComponentInChildren<ParticleSystem>();
    }
    void FixedUpdate()
    {
        if(parts)
        {
            ParticleSystem.MainModule m = parts.main;
            ParticleSystem.EmissionModule me = parts.emission;
            m.startSpeed = actualFlow/0.01f;
            me.rateOverTime = new ParticleSystem.MinMaxCurve(4000*Mathf.Log(1+actualFlow));
        }
        actualFlow = maxFlow*apertura;
    }
}
