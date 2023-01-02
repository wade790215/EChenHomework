using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 提供組裝武器的類別
/// </summary>
/// <returns></returns>
public abstract class WeaponComponent:IGetWeaponData
{
    public WeaponData weaponData { get; private set; }

    public abstract ModuleController AssemblyComponent();

    public  void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }

  
}
