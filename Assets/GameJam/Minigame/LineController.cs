using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LineController : MonoBehaviour
{
    public LineRenderer line;
    public Transform pos1;
    public Transform pos2;

    bool lineShowing;

    void Start (){
        line.positionCount = 2;
        lineShowing = false;
    }
    void Update(){
        if (lineShowing){
            Debug.Log("line showing");
            line.SetPosition(0, pos1.position);
            line.SetPosition(1, pos2.position);
            
            //Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            //Debug.DrawRay (transform.position, forward, Color.green);
        }
    }
    
    public void ToggleLine(){
        lineShowing = true;
    }
}
