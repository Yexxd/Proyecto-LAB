using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankLogic : MonoBehaviour
{
    public float actualLevel, maxLevel;

    public Valve inValve, outValve;

    Transform liquid;

    // Start is called before the first frame update
    void Start()
    {
        liquid = transform.GetChild(3);
        maxLevel = GetComponent<TankEscalable>().alturaTank;
    }

    // Update is called once per frame
    void Update()
    {
        if(inValve)
            actualLevel += inValve.actualFlow*Time.deltaTime;
        if(outValve)
            actualLevel -= outValve.actualFlow*Time.deltaTime;
        
        if(actualLevel>maxLevel)
            actualLevel = maxLevel;
        else if(actualLevel<0)
            actualLevel = 0;
        
        liquid.localScale = new Vector3(1,actualLevel,1);
    }
}
