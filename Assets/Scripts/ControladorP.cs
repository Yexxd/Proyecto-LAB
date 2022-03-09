using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorP : MonoBehaviour
{
    public TanqueDinamico tanque;
    public Valve valvulaControl;


    public float SetPoint, error, kp, bias, ec;
    private void FixedUpdate() {
        error = SetPoint-tanque.h;
        ec = kp*error + bias;

        if(ec>1)
            ec = 1;
        if(ec<0)
            ec = 0;
        valvulaControl.apertura = 1-ec;
    }
}
