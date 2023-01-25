﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Reflection;

public class WeaponDataEditor : EditorWindow
{
    private List<WeaponInfo> weapons = new List<WeaponInfo>();
    private FileHandler fileHandler;
    private Vector2 scrollPos;    
    private string dataPath = $"Assets/Scripts/Data/WeaponsData.asset";
    private string status = "WeaponInfos";
    private bool showWeaponInfo = false;

    [MenuItem("我的編輯器/武器編輯器 #g")]
    public static void ShowWeaponEditroWindow()
    {
        GetWindow(typeof(WeaponDataEditor));
    }

    private void OnEnable()
    {
        fileHandler = new FileHandler();
        weapons = CreateWeaponData();
    }

    private void OnDisable()
    {

    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("新增武器", GUILayout.Height(50)))
            {
                weapons.Add(new WeaponInfo());
                showWeaponInfo = true;
            }

            if (GUILayout.Button("儲存資料", GUILayout.Height(50)))
            {
                fileHandler.SaveToJSON(weapons);
            }

            if (GUILayout.Button("更新列表", GUILayout.Height(50)))
            {
                RefreshWeaponList();
            }

            if (GUILayout.Button("復原設定檔資料", GUILayout.Height(50)))
            {
                var result = MessageBoxController.ShowMessageBox("若未儲存資料，將被設定檔覆蓋!!", "警告", MessageBoxRetrunNumber.OKNo);
                if (result == (int)MessageResult.OK)
                {
                    RecoverSettingData();
                }
                else
                {
                    Debug.Log($"取消復原");
                }
            }
        }
        GUILayout.EndHorizontal();


        GUILayout.BeginVertical();
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
            showWeaponInfo = EditorGUILayout.Foldout(showWeaponInfo, status);
            CreateWeaponDataArea();
            EditorGUILayout.EndScrollView();
        }
        GUILayout.EndVertical();

        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Escape)
        {
            Close();
        }
    }

    private void RefreshWeaponList()
    {
        CreateWeaponDataArea();
    }

    private void RecoverSettingData()
    {
        weapons.Clear();
        weapons.AddRange(fileHandler.ReadListFromJSON<WeaponInfo>());   
        CreateWeaponDataArea();
    }

    private void CreateWeaponDataArea()
    {    
        GUILayout.Space(10);

        for (int i = 0; i < weapons.Count; i++)
        {
            if (showWeaponInfo)
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
                    if (result == (int)MessageResult.OK)
                    {
                        weapons.RemoveAt(i);
                    }
                }
                GUILayout.Space(10);
            }
        }
        GUILayout.Space(10);
    }

   

    private List<WeaponInfo> CreateWeaponData()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
        var weaponsDataPath = Path.Combine(directoryInfo.Parent.FullName, dataPath);

        if (File.Exists(weaponsDataPath) == false)
        {
            var asset = CreateInstance<WeaponEditorData>();
            AssetDatabase.CreateAsset(asset, dataPath);
        }

        var cacheEditorData = AssetDatabase.LoadAssetAtPath<WeaponEditorData>(dataPath);       
        
        return cacheEditorData.weapons;
    }
}
