using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : IAttack, IGetWeaponData
{
    public AttackBase()
    {
        
    }
    public AttackBase(ShottingMode shottingMode)
    {
        this.shottingMode = shottingMode;
    }   

    public ShottingMode shottingMode;
    public WeaponData weaponData;
    protected Transform firePoint;
    public float lastAttackTime = 0f;
    public abstract void Attack();

    public bool IsAttackable()
    {
        return Time.time - lastAttackTime > 1 / weaponData.attackRate;        
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
