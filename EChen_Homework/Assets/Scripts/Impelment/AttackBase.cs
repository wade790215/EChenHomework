using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : IAttack, IGetWeaponData
{
    public WeaponData weaponData { get; private set; }
    public abstract void Attack();   

    public void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;   
    }    
}
