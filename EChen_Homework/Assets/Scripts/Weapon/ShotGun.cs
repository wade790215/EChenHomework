using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : GunWeaponBase
{
    public ShotGun(ShottingMode shottingMode, WeaponData weaponData, Transform firePoint) : base(shottingMode, weaponData, firePoint)
    {
    }       
}
