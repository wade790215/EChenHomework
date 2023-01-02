using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadModule : ModuleBase
{
    private ReloadBase reload; 

    public void Init(ReloadBase reload,WeaponData weaponData)
    {
        this.reload = reload;
        this.reload.SetWeaponData(weaponData);   
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public void Reload()
    {
        if(reload != null)
        {
            reload.Reload();
        }
    }

}
