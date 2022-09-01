using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShottingMode
{
    SingleShot,
    Auto
}

public class GunWeaponBase : WeaponBase
{
  
    public ShottingMode shottingMode;
    public WeaponData WeaponData;    
    public Transform firePoint;   
    public float lastAttackTime = 0f;

    public GunWeaponBase(WeaponData weaponData,Transform firePoint, ShottingMode shottingMode)
    {        
        WeaponData = weaponData;
        this.firePoint = firePoint;
        this.shottingMode = shottingMode;
    }      

    public void Reload()
    {       
        if (WeaponData.currentBulletCount == WeaponData.maxBulletCount)
        {
            Debug.Log($"{WeaponData.weaponName} + Magazine is full.");            
            return;
        }

        WeaponData.currentBulletCount = WeaponData.maxBulletCount;        
        Debug.Log($"{WeaponData.weaponName} + Reloaded");
    }

    public override void Attack(CharacterBase character)
    {
        
    }

    public override void Attack()
    {
        if (!AllowAttack()) return;
        if (WeaponData.currentBulletCount > 0 )
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

    public bool AllowAttack()
    {
        return Time.time - lastAttackTime > 1 / WeaponData.attackRate;
    }

    public void DrawAttackRay()
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




