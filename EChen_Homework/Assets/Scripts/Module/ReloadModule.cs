using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadModule : ModuleBase
{
    private ReloadBase reload; 

    public void SetReload(ReloadBase reload)
    {
        this.reload = reload;
        this.reload.SetWeaponData(weaponData);   
    }

    public void Reload()
    {
        if(reload != null)
        {
            reload.Reload();
        }
    }

}
