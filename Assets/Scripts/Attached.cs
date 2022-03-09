using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Attached : MonoBehaviour
{
    public Transform attachedTo;
    // Start is called before the first frame update
    Vector3 offset;
    bool isAttached;
    private void Update() {
        if(attachedTo)
            if(isAttached)
                transform.position = attachedTo.position + offset;
            else
            {
                isAttached = true;
                offset = transform.position - attachedTo.position;
            }
        else
            isAttached = false;
    }
}
