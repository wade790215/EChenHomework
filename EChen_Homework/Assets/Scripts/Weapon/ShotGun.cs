using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : GunWeaponBase
{
    public ShotGun(ShottingMode shottingMode, WeaponData weaponData) : base(shottingMode, weaponData)
    {
    }

    public override void WeaponAttack()
    {
        Debug.Log("Attack");
    }  
}
