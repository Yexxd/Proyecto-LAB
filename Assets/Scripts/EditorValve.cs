using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class EditorValve : MonoBehaviour
{
}

[CustomEditor(typeof(EditorValve))]
public class CustomEditorValve : Editor
{
    public void OnSceneGUI()
    {
        var t = target as EditorValve;
        var tr = t.transform;
        Handles.color = new Color(0,0,255,0.5f);
        
        if(Handles.Button(tr.position+Vector3.up*0.5f,Quaternion.identity,0.2f,0.2f,Handles.CubeHandleCap))
            tr.eulerAngles += Vector3.forward*90;

        if(Event.current.type == EventType.MouseUp && Event.current.button == 0) {
            tr.GetChild(0).GetComponent<Collider>().enabled = false;
            tr.GetChild(1).GetComponent<Collider>().enabled = false;   
            Debug.Log("raycast casted");
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;
            if( Physics.Raycast( ray, out hit,64,8) )
            { 
                Debug.Log("Hit con " + hit.collider.gameObject.name);
                tr.position = hit.collider.transform.position;
                tr.eulerAngles = hit.collider.transform.eulerAngles;
            }
            tr.GetChild(0).GetComponent<Collider>().enabled = true;
            tr.GetChild(1).GetComponent<Collider>().enabled = true;
        }
    }
}

#endif