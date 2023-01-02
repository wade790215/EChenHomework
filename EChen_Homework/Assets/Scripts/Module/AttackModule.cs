using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackModule : ModuleBase
{           
    private AttackBase attack;
   
    public void Init(AttackBase attack, WeaponData weaponData)
    {
        this.attack = attack;
        attack.SetWeaponData(weaponData);
    }
   
    private void Attack()
    {
        if(attack != null)
        {
            attack.Attack();
        }  
    }

    //public bool IsAttackable()
    //{
    //    if(attack != null)
    //    {
    //        return attack.IsAttackable();
    //    }
    //}

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Attack();           
        }
    }
}
