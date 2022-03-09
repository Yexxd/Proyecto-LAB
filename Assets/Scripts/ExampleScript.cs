using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ExampleScript : MonoBehaviour
{
    public float value = 7.0f;
    
    private void OnMouseDrag() {
        Debug.Log("Mouse Drag");
    }
}

#if UNITY_EDITOR
// A tiny custom editor for ExampleScript component
[CustomEditor(typeof(ExampleScript))]
public class ExampleEditor : Editor
{
    // Custom in-scene UI for when ExampleScript
    // component is selected.
    public void OnSceneGUI()
    {
        var t = target as ExampleScript;
        var tr = t.transform;
        var pos = tr.position;
        // display an orange disc where the object is
        var color = new Color(1, 0.8f, 0.4f, 1);
        Handles.color = color;

        /*
        Vector3 handleMove = Handles.FreeMoveHandle(pos, Quaternion.identity, 0.1f, Vector3.one*0.1f, Handles.RectangleHandleCap);
        if (handleMove.magnitude>0)
            Debug.Log(handleMove);
        */

        Handles.DrawWireDisc(pos, tr.up, 1.0f);
        // display object "value" in scene
        GUI.color = color;
        Handles.Label(pos, t.value.ToString("F1"));

        if(Event.current.type == EventType.MouseUp && Event.current.button == 0) {  
            t.GetComponent<Collider>().enabled = false;
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;
            if( Physics.Raycast( ray, out hit ) )
            {
                
                Debug.Log("Hit con " + hit.collider.gameObject.name);
            }

        }
            t.GetComponent<Collider>().enabled = true;
    }

}

#endif