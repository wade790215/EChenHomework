using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReloadBase : IReload, IGetWeaponData
{
    public WeaponData weaponData;
   
    public abstract void Reload();    

    public void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }  
}
