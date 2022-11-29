using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleBase 
{
    public WeaponData weaponData { protected get; set; }
   
    public void SetUpWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;   
    }
}
