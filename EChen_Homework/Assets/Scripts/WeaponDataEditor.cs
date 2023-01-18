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
    [MenuItem("�ڪ��s�边/�Z���s�边 #g")]
    public static void ShowWeaponEditroWindow()
    {
        GetWindow(typeof(WeaponDataEditor));
    }


    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("�s�W�Z��"))
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
                weapons[i].weaponType = (GunWeaponType)EditorGUILayout.EnumPopup("�Z������", weapons[i].weaponType);
                weapons[i].damage = EditorGUILayout.FloatField("�����O", weapons[i].damage);
                weapons[i].attackRate = EditorGUILayout.FloatField("�C���������", weapons[i].attackRate);
                weapons[i].maxBulletCount = EditorGUILayout.IntField("�̤j�˶�ƶq", weapons[i].maxBulletCount);
                weapons[i].shootingDistance = EditorGUILayout.IntField("���Įg���Z��", weapons[i].shootingDistance);                
                weapons[i].dataIndex = currentListIndex;                 
            }          
        }
        GUILayout.EndVertical();

        if (GUILayout.Button("�x�s���"))
        {
            Debug.Log("�x�s���\");
        }

        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Escape)
        {
            Close();
        }
    }
}
