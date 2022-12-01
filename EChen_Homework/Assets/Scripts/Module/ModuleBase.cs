using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleBase 
{
    public WeaponData weaponData { get; private set; }
   
    public void SetUpWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;   
    }
}
