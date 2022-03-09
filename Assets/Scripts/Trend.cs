using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trend : MonoBehaviour
{
    public LineRenderer trendLine;
    public int maxPoints = 100;
    public void LogTrend(float value, float time)
    {
        if(trendLine.positionCount<maxPoints)
            trendLine.positionCount++;

        CorrerArray(time);
        trendLine.SetPosition(0,new Vector3(0,-value*0.5f,0));
    }

    void CorrerArray(float time)
    {
        for (int i = trendLine.positionCount-1; i > 0; i--)
        {
            trendLine.SetPosition(i,trendLine.GetPosition(i-1)+Vector3.right*time);
        }
    }
}
