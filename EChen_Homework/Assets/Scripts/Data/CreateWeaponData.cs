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
    [Header("�Z���W��")]
    public GunWeapon weaponName;
    [Header("������")]
    public string owner;
    [Header("�����O")]
    public float attack;
    [Header("�@�[��")]
    public float durability;   
    /// <summary>
    /// �@�����������
    /// </summary>
    [Header("�@�����������")]
    public float attackRate;
    [Header("�ثe�u��")]
    public int currentBulletCount;
    [Header("�u�Įe�q")]
    public int maxBulletCount;      
}





