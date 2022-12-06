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
    [Header("�Z���W��")]
    public GunWeapon weaponName;
    [Header("������")]
    public string owner;
    [Header("�����O")]
    public float damage;
    [Header("�@�[��")]
    public float durability;   
    /// <summary>
    /// �@�����������
    /// </summary>
    [Header("�@�����������")]
    public float attackRate;
    [Header("�C�o�l�u���g�ƶq")]
    public int scatterCount;
    [Header("�ثe�u��")]
    public int currentBulletCount;
    [Header("�u�Įe�q")]
    public int maxBulletCount;
    [Header("�ثe��q")]
    public int currentEnergy;
    [Header("�̤j��q")]
    public int maxEnergy;
    [Header("�̤j������������")]
    public float verticalMaxAngle;
    [Header("�̤p������������")]
    public float verticalMinAngle;
    [Header("�̤j������������")]
    public float horiziontalMaxAngle;
    [Header("�̤p������������")]
    public float horiziontalMinAngle;
    [Header("���Įg���Z��")]
    public float shootingDistance;
    [Header("�j�f�y��")]
    public Vector3 firePoint;
}





