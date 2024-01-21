using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Wire : MonoBehaviour
{
    Vector2 source;
    Vector2 dest; 
    float m;
    float lineThickness;

    void Line (Vector2 s, Vector2 t, float thick){
        this.source = s;
        this.dest = t;
        m = (t.y-s.y)/(t.x-s.x);
        this.lineThickness = thick;
    }
    void DrawLine(){
        Vector2 here = new Vector2(source.x,source.y);
    }

}
