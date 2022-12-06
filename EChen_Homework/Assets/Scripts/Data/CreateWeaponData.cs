using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "CreateModelData/CreateWeaponData")]
public class CreateWeaponData : ScriptableObject
{
    public WeaponData WeaponData;   
}

[Serializable]
public class WeaponData 
{
    [Header("武器名稱")]
    public GunWeapon weaponName;
    [Header("持有者")]
    public string owner;
    [Header("攻擊力")]
    public float damage;
    [Header("耐久度")]
    public float durability;   
    /// <summary>
    /// 一秒內能攻擊次數
    /// </summary>
    [Header("一秒內能攻擊次數")]
    public float attackRate;
    [Header("每發子彈散射數量")]
    public int scatterCount;
    [Header("目前彈藥")]
    public int currentBulletCount;
    [Header("彈藥容量")]
    public int maxBulletCount;
    [Header("目前能量")]
    public int currentEnergy;
    [Header("最大能量")]
    public int maxEnergy;
    [Header("最大垂直攻擊角度")]
    public float verticalMaxAngle;
    [Header("最小垂直攻擊角度")]
    public float verticalMinAngle;
    [Header("最大水平攻擊角度")]
    public float horiziontalMaxAngle;
    [Header("最小水平攻擊角度")]
    public float horiziontalMinAngle;
    [Header("有效射擊距離")]
    public float shootingDistance;
    [Header("槍口座標")]
    public Vector3 firePoint;
}





