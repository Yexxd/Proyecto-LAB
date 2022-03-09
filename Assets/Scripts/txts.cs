using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class txts : MonoBehaviour
{
    public void SetTxt(float f)
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = f.ToString("F2");
    }
}
