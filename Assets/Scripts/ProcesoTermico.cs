using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcesoTermico : MonoBehaviour
{

    public float Ti, T, Tc, qc, dT, dTc, Tci;
    public float q, p,  U, A, Cp, Cv, V, pc, Vc, Cvc, Cpc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        dT = (q*p*Cp*Ti - U*A*(T-Tc) - q*p*Cp*T)/(V*p*Cv);
        dTc = (qc*pc*Cpc*Tci + U*A*(T-Tc) -qc*pc*Cpc*Tc)/(Vc*pc*Cvc);

        T  += dT;
        Tc += dTc;
    }
}
