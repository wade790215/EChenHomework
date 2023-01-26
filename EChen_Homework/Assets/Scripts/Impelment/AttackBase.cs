using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShottingMode
{
    SingleShot,
    AutoShot,
    TripleShot
}
public abstract class AttackBase : IAttack, IGetWeaponData
{
    public ShottingMode shottingMode;
    public WeaponData weaponData;
    protected Transform firePoint;
    public abstract void Attack();

    public bool IsAttackable()
    {
        return false;
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }
    public void SetFirePoint(Transform firePoint)
    {
        this.firePoint = firePoint; 
    }
}
