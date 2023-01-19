using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "CreateWeaponList")] 
public class WeaponEditorData : ScriptableObject
{
    public List<WeaponInfo> weapons = new List<WeaponInfo>();
}

[Serializable]
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
