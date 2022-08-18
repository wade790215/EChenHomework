using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "CreateModelData/CreateWeaponData")]
public class CreateWeaponData : ScriptableObject
{
    public List<WeaponData> weaponData = new List<WeaponData>();   
}

[Serializable]
public class WeaponData : DataBase
{
    public string weaponName;
    public string owner;
    public float attack;       
    public float durability;
    public float lastAttackTime = 0f;
    /// <summary>
    /// 一秒內能攻擊次數
    /// </summary>
    public float attackRate;
    public int currentBulletCount;
    public int maxBulletCount;  
    public bool isReloading;
}





