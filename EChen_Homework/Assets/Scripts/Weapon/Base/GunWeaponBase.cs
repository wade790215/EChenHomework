using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunWeaponBase : WeaponBase
{
    public GameObject weaponModel;
    public Transform firePoint;
    public bool isReloading;

    public GunWeaponBase(ShottingMode shottingMode,WeaponData weaponData,Transform firePoint)
    {
        gunShottingMode = shottingMode;
        WeaponData = weaponData;
        this.firePoint = firePoint;
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
            DrawAttackRay();
        }
        else
        {
            Debug.Log($"{WeaponData.weaponName} + NeedReload");
        }
        lastAttackTime = Time.time;        
    }

    public virtual void DrawAttackRay()
    {
        for (int i = 0; i < WeaponData.scatterCount; i++)
        {
            var direction = firePoint.forward;
            var spread = Vector3.zero;
            var vMax = Tool.Angle2Value(Vector3.up, WeaponData.verticalMaxAngle);
            var vMin = Tool.Angle2Value(Vector3.up, WeaponData.verticalMinAngle);
            var hMax = Tool.Angle2Value(Vector3.right, WeaponData.horiziontalMaxAngle);
            var hMin = Tool.Angle2Value(Vector3.right, WeaponData.horiziontalMinAngle);

            spread += firePoint.up * Random.Range(vMin, vMax);
            spread += firePoint.right * Random.Range(hMin, hMax);
            direction += spread;

            if (Physics.Raycast(firePoint.position, direction, out RaycastHit hit, WeaponData.shootingDistance))
            {
                Debug.DrawLine(firePoint.position, hit.point, Color.green, 5f);
            }
            else
            {
                Debug.DrawLine(firePoint.position, firePoint.position + direction * WeaponData.shootingDistance, Color.red, 5f);
            }
        }        
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
