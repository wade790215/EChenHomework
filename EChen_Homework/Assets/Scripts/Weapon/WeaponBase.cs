using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase
{    
    public abstract void Attack(CharacterBase character);
    public abstract void Attack();    
    public virtual void ShowAttackEffect(Vector3 hitPoint,float displayTime)
    {

    }
    
}



