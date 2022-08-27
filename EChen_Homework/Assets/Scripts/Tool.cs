using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tool 
{
    public static float Angle2Value(Vector3 direction, float angle)
    {
        var costheta = Mathf.Cos(angle * Mathf.PI / 180);
        var r = direction / costheta;
        var result = Mathf.Sin(angle * Mathf.PI / 180) * r.magnitude;
        return result;
    }
}
