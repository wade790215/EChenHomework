using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChangeObjInfo))]
public class EditorInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); //需要呼叫Base不然自定義的腳本參數會無法顯示

         ChangeObjInfo obj = (ChangeObjInfo)target;
         obj.Texture =  EditorGUILayout.ObjectField("選擇貼圖", obj.Texture, typeof(Texture), true) as Texture;
    }
}
