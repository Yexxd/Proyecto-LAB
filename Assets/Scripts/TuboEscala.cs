using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


#if UNITY_EDITOR
[ExecuteInEditMode]
public class TuboEscala : MonoBehaviour
{
    [Tooltip("Diametro del tubo en cm")]
    public float diametro;

    [Tooltip("Longitud")]
    public float longitud;
    public bool conPuntaFinal;
    public bool conPuntaInicial;
    private void OnValidate() {
        bool isNormal = GetComponent<MeshFilter>().sharedMesh.name == "Tubo";
        Transform inicio = transform.GetChild(0);
        Transform final  = transform.GetChild(1);
        if(isNormal)
        {
            transform.localScale = new Vector3(diametro, diametro, longitud);
            inicio.localScale = new Vector3(1,1,-2/transform.localScale.z);
            final.localScale = new Vector3(1,1,-2/transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(diametro, diametro, diametro);
            inicio.GetComponent<SphereCollider>().radius = 0.15f/diametro;
            final.GetComponent<SphereCollider>().radius = 0.15f/diametro;
        }

        inicio.GetComponent<MeshRenderer>().enabled = conPuntaInicial;
        final.GetComponent<MeshRenderer>().enabled = conPuntaFinal;
    }
}

[CustomEditor(typeof(TuboEscala))]
public class TubosEditor : Editor
{
    // Custom in-scene UI for when ExampleScript
    // component is selected.
    private void OnMouseUp() {
        Debug.Log("OnMouseUp Editor");
    }

    public void OnSceneGUI()
    {
        var t = target as TuboEscala;
        var tr = t.transform;
        Handles.color = new Color(0,0,255,0.5f);
        
        if(Handles.Button(tr.position+Vector3.up*0.5f,Quaternion.identity,0.2f,0.2f,Handles.CubeHandleCap))
            tr.eulerAngles += Vector3.forward*90;

        if(Event.current.type == EventType.MouseUp && Event.current.button == 0) {
            tr.GetChild(0).GetComponent<Collider>().enabled = false;
            tr.GetChild(1).GetComponent<Collider>().enabled = false;   
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;
            if( Physics.Raycast( ray, out hit,64,8) )
            { 
                Debug.Log("Hit con " + hit.collider.gameObject.name);
                tr.position = hit.collider.transform.position;
                tr.eulerAngles = hit.collider.transform.eulerAngles;
                TuboEscala tubo = hit.collider.GetComponentInParent<TuboEscala>();
                if(tubo)
                    t.diametro = tubo.diametro;
                    
                t.SendMessage("OnValidate");
            }
            tr.GetChild(0).GetComponent<Collider>().enabled = true;
            tr.GetChild(1).GetComponent<Collider>().enabled = true;
        }
    }
}

/*            Collider[] a = Physics.OverlapSphere(tr.position,0.2f*t.diametro);
            foreach(Collider c in a)
                if(c.isTrigger && c.tag == "Tubos" && c !=  tr.GetChild(1).GetComponent<SphereCollider>() && c !=  tr.GetChild(0).GetComponent<SphereCollider>())
                    {
                        tr.position = c.transform.position;
                        tr.eulerAngles = c.transform.eulerAngles;
                        return;
                    }    */
#endif