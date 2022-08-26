using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGizmos : MonoBehaviour
{
    public Vector3 Distance;
    public Vector3 direction;
    public Vector3 spread;
    public float range = 10f;
    public Transform traget;
    public float verticalMaxAngle, verticalMinAngle;
    public float horiziontalMaxAngle, horiziontalMinAngle;   
    public float vMax,vMin; 
    public float hMax,hMin;
    
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        vMax = Angle2Value(Vector3.up, verticalMaxAngle);
        vMin = Angle2Value(Vector3.up, verticalMinAngle);
        hMax = Angle2Value(Vector3.right, horiziontalMaxAngle);
        hMin = Angle2Value(Vector3.right, horiziontalMinAngle);

        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < 8; i++)
            {
                direction = transform.forward;
                spread = Vector3.zero;
                spread += transform.up * UnityEngine.Random.Range(vMin, vMax);                
                spread += transform.right * UnityEngine.Random.Range(hMin, hMax);
                direction += spread;

                if (Physics.Raycast(transform.position, direction, out RaycastHit hit, range))
                {
                    Debug.DrawLine(transform.position, hit.point, Color.green, 10f);
                }
                else
                {
                    Debug.DrawLine(transform.position, transform.position + direction * range, Color.red, 10f);
                }
            }

        }
    }

   
    private float Angle2Value(Vector3 direction, float angle)
    {
        var costheta = Mathf.Cos(angle * Mathf.PI / 180);          
        var r = direction / costheta;
        var result = Mathf.Sin(angle * Mathf.PI / 180) * r.magnitude;        
        return result;
    }   
}

public static class GizmosTools
{
    public static void DrawWireSemicircle(Vector3 origin, Vector3 direction, float radius, int angle)
    {
        DrawWireSemicircle(origin, direction, radius, angle, Vector3.up);
    }

    public static void DrawWireSemicircle(Vector3 origin, Vector3 direction, float radius, int angle, Vector3 axis)
    {
        Vector3 leftdir = Quaternion.AngleAxis(-angle / 2, axis) * direction;
        Vector3 rightdir = Quaternion.AngleAxis(angle / 2, axis) * direction;

        Vector3 currentP = origin + leftdir * radius;
        Vector3 oldP;
        if (angle != 360)
        {
            Gizmos.DrawLine(origin, currentP);
        }
        for (int i = 0; i < angle / 10; i++)
        {
            Vector3 dir = Quaternion.AngleAxis(10 * i, axis) * leftdir;
            oldP = currentP;
            currentP = origin + dir * radius;
            Gizmos.DrawLine(oldP, currentP);
        }
        oldP = currentP;
        currentP = origin + rightdir * radius;
        Gizmos.DrawLine(oldP, currentP);
        if (angle != 360)
        {
            Gizmos.DrawLine(currentP, origin);
        }

    }

    public static Mesh SemicircleMesh(float radius, int angle, Vector3 axis)
    {
        Vector3 leftdir = Quaternion.AngleAxis(-angle / 2, axis) * Vector3.forward;
        Vector3 rightdir = Quaternion.AngleAxis(angle / 2, axis) * Vector3.forward;
        int pcount = angle / 10;
        //顶点
        Vector3[] vertexs = new Vector3[3 + pcount];
        vertexs[0] = Vector3.zero;
        int index = 1;
        vertexs[index] = leftdir * radius;
        index++;
        for (int i = 0; i < pcount; i++)
        {
            Vector3 dir = Quaternion.AngleAxis(10 * i, axis) * leftdir;
            vertexs[index] = dir * radius;
            index++;
        }
        vertexs[index] = rightdir * radius;
        //三角面
        int[] triangles = new int[3 * (1 + pcount)];
        for (int i = 0; i < 1 + pcount; i++)
        {
            triangles[3 * i] = 0;
            triangles[3 * i + 1] = i + 1;
            triangles[3 * i + 2] = i + 2;
        }

        Mesh mesh = new Mesh();
        mesh.vertices = vertexs;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        return mesh;
    }

}
