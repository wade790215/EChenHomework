using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class WeaponDataEditor : EditorWindow
{   
    private List<WeaponInfo> weapons = new List<WeaponInfo>();
    private FileHandler fileHandler;      
    private string dataPath = $"Assets/Scripts/Data/WeaponsData.asset";
    private string weaponsDataPath;   

    [MenuItem("�ڪ��s�边/�Z���s�边 #g")]
    public static void ShowWeaponEditroWindow()
    {
        GetWindow(typeof(WeaponDataEditor));
    }

    private void OnEnable()
    {       
        fileHandler = new FileHandler();
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
        weaponsDataPath = Path.Combine(directoryInfo.Parent.FullName, dataPath);

        if (File.Exists(weaponsDataPath) == false)
        {
            var asset = CreateInstance<WeaponEditorData>();
            AssetDatabase.CreateAsset(asset, dataPath);
        }
        else
        {
            Debug.Log("�ɮפw�s�b");
        }
        var cacheEditorData = AssetDatabase.LoadAssetAtPath<WeaponEditorData>(dataPath);
        weapons = cacheEditorData.weapons;
    }

    private void OnDisable()
    {
        
    }


    private void OnGUI()
    {        
        GUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("�s�W�Z��",GUILayout.Height(50)))
            {
                weapons.Add(new WeaponInfo());
            }
          
            if (GUILayout.Button("�x�s���", GUILayout.Height(50)))
            {
                fileHandler.SaveToJSON(weapons);
                Debug.Log("�x�s���\");
            }
        }
        GUILayout.EndHorizontal();  
        

        GUILayout.BeginVertical();
        {
            GUILayout.Space(10);
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].weaponType = (GunWeaponType)EditorGUILayout.EnumPopup("�Z������", weapons[i].weaponType);
                weapons[i].damage = EditorGUILayout.FloatField("�����O", weapons[i].damage);
                weapons[i].attackRate = EditorGUILayout.FloatField("�C���������", weapons[i].attackRate);
                weapons[i].maxBulletCount = EditorGUILayout.IntField("�̤j�˶�ƶq", weapons[i].maxBulletCount);
                weapons[i].shootingDistance = EditorGUILayout.IntField("���Įg���Z��", weapons[i].shootingDistance);                
                weapons[i].dataIndex = i;

                if (GUILayout.Button("�����Z��"))
                {
                    weapons.RemoveAt(i);
                }
                GUILayout.Space(10);
            }
            GUILayout.Space(10);
        }
        GUILayout.EndVertical();        

        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Escape)
        {
            Close();
        }
    }
}
