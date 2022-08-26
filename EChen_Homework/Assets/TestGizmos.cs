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
    
    public float maxAngle, minAngle;
    public float degrees;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var costheta = Mathf.Cos(degrees * Mathf.PI / 180);
        var r = Vector3.forward / costheta;
        var result = Mathf.Sin(degrees * Mathf.PI / 180) * r;
        Debug.Log(result);
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < 8; i++)
            {
                direction = transform.forward;
                spread = Vector3.zero;
                //spread += transform.up * UnityEngine.Random.Range(minAngle, maxAngle);                
                //spread += transform.right * UnityEngine.Random.Range(minAngle, maxAngle);
                
                //direction += spread.normalized * UnityEngine.Random.Range(0, maxAngle);
                
                if (Physics.Raycast(transform.position, direction, out RaycastHit hit, range))
                {
                    Debug.DrawLine(transform.position, hit.point, Color.green, 1f);
                }
                else
                {
                    Debug.DrawLine(transform.position, transform.position + direction * range, Color.red, 1f);
                }
            }

        }
    }

    void OnDrawGizmos()
    {

        GizmosTools.DrawWireSemicircle(transform.position , transform.forward * range, 1f, 45, Vector3.up);
        GizmosTools.DrawWireSemicircle(transform.position , transform.forward * range, 1f, 45, Vector3.right);



        //GizmosTools.DrawWireSemicircle(this.transform.position, this.transform.forward, 2, 0);        

        //for (int i = 1; i < 50; i++)
        //{
        //    Gizmos.color = Color.yellow;  
        //    var offset = new Vector3(0,i, 0);
        //    Gizmos.DrawSphere(transform.position + Distance + offset, 0.5f);
        //}
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
