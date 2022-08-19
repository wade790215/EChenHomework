using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "CreateModelData/CreateWeaponData")]
public class CreateWeaponData : ScriptableObject
{
    public List<WeaponData> WeaponData;   
}

[Serializable]
public class WeaponData : DataBase
{
    [Header("武器名稱")]
    public GunWeapon weaponName;
    [Header("持有者")]
    public string owner;
    [Header("攻擊力")]
    public float attack;
    [Header("耐久度")]
    public float durability;   
    /// <summary>
    /// 一秒內能攻擊次數
    /// </summary>
    [Header("一秒內能攻擊次數")]
    public float attackRate;
    [Header("目前彈藥")]
    public int currentBulletCount;
    [Header("彈藥容量")]
    public int maxBulletCount;      
}





