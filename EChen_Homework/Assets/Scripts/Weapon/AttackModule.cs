using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackModule 
{   
    public float lastAttackTime = 0f;
    public Transform firePoint;
    private WeaponData weaponData;
    private IAttack attack;    

    public AttackModule(WeaponData weaponData,Transform firePoint)
    {
        this.weaponData = weaponData;
        this.firePoint = firePoint;
    }

    public void SetAttack(IAttack attack)
    {
        this.attack = attack;
    }
   
    public void Attack()
    {
        if (!AllowAttack())
            return;

        if (weaponData.currentBulletCount > 0)
        {
            weaponData.currentBulletCount--;
            attack.DrawAttack();
            Debug.Log($"{weaponData.weaponName} + Attack");
        }
        else
        {
            Debug.Log($"{weaponData.weaponName} + NeedReload");
        }

        lastAttackTime = Time.time;
    }

    public void Reload()
    {
        if (weaponData.currentBulletCount == weaponData.maxBulletCount)
        {
            Debug.Log($"{weaponData.weaponName} + Magazine is full.");
            return;
        }

        weaponData.currentBulletCount = weaponData.maxBulletCount;
        Debug.Log($"{weaponData.weaponName} + Reloaded");
    }

    public bool AllowAttack()
    {
        return Time.time - lastAttackTime > 1 / weaponData.attackRate;
    }  
}
