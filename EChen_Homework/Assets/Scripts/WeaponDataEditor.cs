using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class WeaponDataEditor : EditorWindow
{   
    private List<WeaponInfo> weapons = new List<WeaponInfo>();
    private FileHandler fileHandler;
    private Vector2 scrollPos;
    private string dataPath = $"Assets/Scripts/Data/WeaponsData.asset";
    private string weaponsDataPath;   

    [MenuItem("我的編輯器/武器編輯器 #g")]
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
            Debug.Log("檔案已存在");
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
            if (GUILayout.Button("新增武器",GUILayout.Height(50)))
            {
                weapons.Add(new WeaponInfo());
            }
          
            if (GUILayout.Button("儲存資料", GUILayout.Height(50)))
            {
                fileHandler.SaveToJSON(weapons);                
            }
        }
        GUILayout.EndHorizontal();  
        

        GUILayout.BeginVertical();
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
            GUILayout.Space(10);
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].weaponType = (GunWeaponType)EditorGUILayout.EnumPopup("武器類型", weapons[i].weaponType);
                weapons[i].damage = EditorGUILayout.FloatField("攻擊力", weapons[i].damage);
                weapons[i].attackRate = EditorGUILayout.FloatField("每秒攻擊次數", weapons[i].attackRate);
                weapons[i].maxBulletCount = EditorGUILayout.IntField("最大裝填數量", weapons[i].maxBulletCount);
                weapons[i].shootingDistance = EditorGUILayout.IntField("有效射擊距離", weapons[i].shootingDistance);                
                weapons[i].dataIndex = i;

                if (GUILayout.Button("移除武器"))
                {
                    var result = MessageBoxController.ShowMessageBox("確定要移除!!", "警告", MessageBoxRetrunNumber.OKNo);
                    if(result == (int)MessageResult.OK)
                    {
                        weapons.RemoveAt(i);
                    }
                }
                GUILayout.Space(10);
            }
            GUILayout.Space(10);
            EditorGUILayout.EndScrollView();
        }
        GUILayout.EndVertical();        

        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Escape)
        {
            Close();
        }
    }
}
