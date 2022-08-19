using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunWeaponBase : WeaponBase
{
    public GameObject weaponModel;    
    public bool isReloading;

    public GunWeaponBase(ShottingMode shottingMode,WeaponData weaponData)
    {
        gunShottingMode = shottingMode;
        WeaponData = weaponData;    
    }
    
    public ShottingMode gunShottingMode;
    public GunWeaponState gunState = GunWeaponState.CanShoot;
    private ShottingMode shottingMode;

    public void Reload()
    {
        gunState = GunWeaponState.Reloading;
        if (WeaponData.currentBulletCount == WeaponData.maxBulletCount)
        {
            Debug.Log($"{WeaponData.weaponName} + Magazine is full.");
            gunState = GunWeaponState.CanShoot;
            return;
        }

        WeaponData.currentBulletCount = WeaponData.maxBulletCount;
        gunState = GunWeaponState.CanShoot;
        Debug.Log($"{WeaponData.weaponName} + Reloaded");
    }

    public override void Attack(CharacterBase character)
    {
        
    }

    public override void Attack()
    {
        if (!AllowAttack()) return;
        if (WeaponData.currentBulletCount > 0 && gunState == GunWeaponState.CanShoot)
        {
            Debug.Log($"{WeaponData.weaponName} + Attack");
            WeaponData.currentBulletCount--;
        }
        else
        {
            Debug.Log($"{WeaponData.weaponName} + NeedReload");
        }
        lastAttackTime = Time.time;

        WeaponAttack();
    }

    public virtual void WeaponAttack()
    {
        //TODO 子彈攻擊範圍寫在這裡設定
    }
}

public enum ShottingMode
{
    SingleShot,    
    Auto
}

public enum GunWeaponState
{
    CanShoot,
    Locked,
    Reloading
}
