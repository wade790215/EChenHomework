using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase
{
    public float lastAttackTime = 0f;
    public WeaponData WeaponData;
    public abstract void Attack(CharacterBase character);
    public abstract void Attack();    
    public virtual void ShowAttackEffect(Vector3 hitPoint,float displayTime)
    {

    }
    public bool AllowAttack()
    {
        return Time.time - lastAttackTime > 1 / WeaponData.attackRate;
    }
}



