using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunWeaponBase : WeaponBase
{
    public GameObject weaponModel;
    public GunWeaponBase(ShottingMode shottingMode)
    {
        gunShottingMode = shottingMode;
    }

    public ShottingMode gunShottingMode;
    public GunWeaponState gunState = GunWeaponState.CanShoot;
    public void Reload()
    {
        gunState = GunWeaponState.Reloading;
        if (WeaponData.currentBulletCount == WeaponData.maxBulletCount)
        {
            Debug.Log($"Magazine is full.");
            gunState = GunWeaponState.CanShoot;
            return;
        }

        WeaponData.currentBulletCount = WeaponData.maxBulletCount;
        gunState = GunWeaponState.CanShoot;
        Debug.Log($"{WeaponData.weaponName} + Reloaded");
    }

    public override void Attack()
    {
        if (!AllowAttack()) return;
        if (WeaponData.currentBulletCount > 0 && gunState == GunWeaponState.CanShoot)
        {
            Debug.Log($"Attack");
            WeaponData.currentBulletCount--;
        }
        else
        {
            Debug.Log($"NeedReload");
        }

        WeaponData.lastAttackTime = Time.time;
    }
}

public enum ShottingMode
{
    SingleShot,
    TripleShot,
    Auto
}

public enum GunWeaponState
{
    CanShoot,
    Locked,
    Reloading
}
