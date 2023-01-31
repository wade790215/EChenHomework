using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackModule : ModuleBase
{           
    private AttackBase attack;
   
    public void Init(AttackBase attack, WeaponData weaponData,Transform firePoint)
    {
        this.attack = attack;
        attack.SetWeaponData(weaponData);
        attack.SetFirePoint(firePoint);
    }
   
    private void Attack()
    {
        if(attack != null)
        {
            attack.Attack();
        }  
    }
    
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Attack();           
        }
    }
}
