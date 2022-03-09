using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEscalable : MonoBehaviour
{
    [Tooltip("Altura del tanque desde la base (sin incluir las patas)")]
    public float alturaTank;

    [Tooltip("Altura desde el suelo hasta la base (largo de las patas)")]
    public float largoPatas;

    [Tooltip("Area del tanque")]
    public float diametro;

    private void OnValidate() {
        transform.GetChild(2).GetChild(2).localPosition = Vector3.forward*largoPatas;
        transform.GetChild(2).GetChild(0).localPosition = Vector3.forward*(alturaTank+largoPatas);
        transform.GetChild(2).localScale = new Vector3(diametro*0.5f,diametro*0.5f,1);
        transform.GetChild(3).localPosition = Vector3.up*largoPatas;
        transform.GetChild(3).localScale = new Vector3(diametro*0.5f,0, diametro*0.5f);
    }
}
