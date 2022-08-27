using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : GunWeaponBase
{
    public MachineGun(ShottingMode shottingMode, WeaponData weaponData, Transform firePoint) : base(shottingMode, weaponData, firePoint)
    {
    } 
}
