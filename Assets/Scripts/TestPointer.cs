using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.Events;

 [System.Serializable]
public class TestPointer : MonoBehaviour
{
    public Pointer<float> a;
    // Start is called before the first frame update
        public EventTrigger questEvent;
 
     // Event Triggers
        public void CallEvent() {
            questEvent.Invoke();
        }
    
}


 
 [System.Serializable]
 public class EventTrigger : UnityEvent {}
 

public class Pointer<T>
{
     public T value;
}
