using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChangeObjInfo))]
public class EditorScene : Editor
{
    private void OnSceneGUI()
    {
        ChangeObjInfo objInfo = (ChangeObjInfo)target;  

        Handles.Label(objInfo.transform.position + Vector3.up, objInfo.name + ":" + objInfo.transform.position.ToString());

        Handles.BeginGUI();

        GUILayout.BeginArea(new Rect(5, 5, 150, 200));
        GUI.color = Color.black;
        GUILayout.Label("選擇顏色");
        GUI.color = Color.red;
        if (GUILayout.Button("紅色"))
        {
            objInfo.GetComponent<Renderer>().sharedMaterial.color = Color.red;
        }

        GUI.color = Color.white;
        if (GUILayout.Button("白色"))
        {
            objInfo.GetComponent<Renderer>().sharedMaterial.color = Color.white;
        }

        GUILayout.EndArea();

        Handles.EndGUI();
    }
}
