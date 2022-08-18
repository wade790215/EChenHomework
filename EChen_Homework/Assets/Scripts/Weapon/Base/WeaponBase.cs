using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase
{
    public WeaponData WeaponData; 
    public abstract void Attack(CharacterBase character);
    public abstract void Attack();
    public abstract void SetModel(GameObject weaponModel);
    public virtual void ShowAttackEffect(Vector3 hitPoint,float displayTime)
    {

    }
    public bool AllowAttack()
    {
        return Time.time - WeaponData.lastAttackTime > 1 / WeaponData.attackRate;
    }
}



