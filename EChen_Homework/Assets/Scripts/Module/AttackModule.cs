using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackModule :ModuleBase
{   
    public float lastAttackTime = 0f;
    public Transform firePoint;    
    private IAttack attack;    

    public AttackModule(Transform firePoint)
    {        
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
        if (attack != null)
        {
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
        else
        {
            Debug.LogError($"¥¼³]©wAttackModule");
        }
       
    }

    
    public bool AllowAttack()
    {
        return Time.time - lastAttackTime > 1 / weaponData.attackRate;
    }  
}
