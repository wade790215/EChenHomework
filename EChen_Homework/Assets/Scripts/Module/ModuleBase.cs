using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleBase :IGetWeaponData
{
    public WeaponData weaponData { get; private set; }  

    public void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }
}
