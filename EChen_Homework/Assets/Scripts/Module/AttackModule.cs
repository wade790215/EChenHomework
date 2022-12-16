using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackModule : ModuleBase
{           
    private AttackBase attack;
   
    public void SetAttack(AttackBase attack)
    {
        this.attack = attack;
        this.attack.SetWeaponData(weaponData);
    }
   
    public void Attack()
    {
        if(attack != null)
        {
            attack.Attack();
        }  
    }   
}
