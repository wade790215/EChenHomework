using System;
using System.Collections.Generic;
using UnityEngine;

public enum GunWeaponType
{
    Pistol,
    MachineGun,
    ShotGun,
    AssaultGun
}

public enum ReloadingType
{
    EachFiling,
    Full,    
}

public enum DetectingType
{
    Ray,
    Sphere,    
}

public enum ShottingMode
{
    SingleShot,
    AutoShot,
    TripleShot
}

[CreateAssetMenu(fileName = "WeaponData", menuName = "CreateModelData/CreateWeaponData")]
public class CreateWeaponData : ScriptableObject
{
    public List<WeaponData> WeaponDatas = new List<WeaponData>();   
}


[Serializable]
public class WeaponData 
{
    [Header(HeaderString.h_WeaponType)]
    public GunWeaponType weaponType;

    [Header(HeaderString.h_DetectingType)]
    public DetectingType detectingType;

    [Header(HeaderString.h_ReloadingType)]
    public ReloadingType reloadingType;

    [Header(HeaderString.h_ShottingMode)]
    public ShottingMode shottingMode;

    [Header(HeaderString.h_Owner)]
    public string owner;

    [Header(HeaderString.h_Damage)]
    public float damage = 1;

    [Header(HeaderString.h_Durability)]
    public float durability = 100;  
   
    [Header(HeaderString.h_AttackRate)]
    public float attackRate = 1;

    [Header(HeaderString.h_ScatterCount)]
    public int scatterCount = 1;

    [Header(HeaderString.h_currentBulletCount)]
    public int currentBulletCount = 10;

    [Header(HeaderString.h_MaxBulletCount)]
    public int maxBulletCount = 10;   

    [Header(HeaderString.h_VerticalMaxAngle)]
    public float verticalMaxAngle = 10;

    [Header(HeaderString.h_VerticalMinAngle)]
    public float verticalMinAngle =  0;

    [Header(HeaderString.h_HoriziontalMaxAngle)]
    public float horiziontalMaxAngle = 10;

    [Header(HeaderString.h_HoriziontalMinAngle)]
    public float horiziontalMinAngle = 0; 

    [Header(HeaderString.h_ShootingDistance)]
    public float shootingDistance = 1;   

    [HideInInspector]
    public int dataIndex;
}





