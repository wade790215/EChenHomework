using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponInfo
{
    public GunWeaponType weaponType;
    public float damage;
    public float attackRate;
    public int scatterCount;
    public int maxBulletCount;
    public int shootingDistance;
    public int dataIndex;
}

public class WeaponDataEditor : EditorWindow
{
    public Dictionary<int , WeaponInfo> weapons = new Dictionary<int, WeaponInfo>();    
    private int currentListIndex = -1;
    [MenuItem("我的編輯器/武器編輯器 #g")]
    public static void ShowWeaponEditroWindow()
    {
        GetWindow(typeof(WeaponDataEditor));
    }


    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("新增武器"))
            {
                currentListIndex++;
                weapons.Add(currentListIndex,new WeaponInfo());                
            }          
        }
        GUILayout.EndHorizontal();  
        

        GUILayout.BeginVertical();
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].weaponType = (GunWeaponType)EditorGUILayout.EnumPopup("武器類型", weapons[i].weaponType);
                weapons[i].damage = EditorGUILayout.FloatField("攻擊力", weapons[i].damage);
                weapons[i].attackRate = EditorGUILayout.FloatField("每秒攻擊次數", weapons[i].attackRate);
                weapons[i].maxBulletCount = EditorGUILayout.IntField("最大裝填數量", weapons[i].maxBulletCount);
                weapons[i].shootingDistance = EditorGUILayout.IntField("有效射擊距離", weapons[i].shootingDistance);                
                weapons[i].dataIndex = currentListIndex;                 
            }          
        }
        GUILayout.EndVertical();

        if (GUILayout.Button("儲存資料"))
        {
            Debug.Log("儲存成功");
        }

        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Escape)
        {
            Close();
        }
    }
}
