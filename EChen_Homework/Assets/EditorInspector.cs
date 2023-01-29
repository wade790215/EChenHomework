using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChangeObjInfo))]
public class EditorInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); //�ݭn�I�sBase���M�۩w�q���}���ѼƷ|�L�k���

         ChangeObjInfo obj = (ChangeObjInfo)target;
         obj.Texture =  EditorGUILayout.ObjectField("��ܶK��", obj.Texture, typeof(Texture), true) as Texture;
    }
}
