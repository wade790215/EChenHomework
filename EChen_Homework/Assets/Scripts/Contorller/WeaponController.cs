using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponController : MonoBehaviour
{
    public GunWeaponType weaponType;    
    public Transform firePoint;   
    private WeaponFactory weaponFactory;
    private WeaponComponent myWeapon;
    private ModuleController moduleController;

    public void OnStart()
    {       
        if(weaponFactory.TryGetWeaponComponent(weaponType, out WeaponComponent myWeapon))
        {
            this.myWeapon = myWeapon;
            this.myWeapon.SetFirePoint(firePoint);
            moduleController = this.myWeapon.AssemblyComponentFromSetting();
        }
        else
        {
            Debug.Log($"找不到武器{weaponType}，請檢查武器工廠是否有製造該武器");
        }
    }

    public void OnUpdate()
    {
        if (myWeapon != null)
        {            
            if (moduleController != null)
            {
                if (moduleController.TryGetModuleBase(typeof(AttackModule),out AttackModule attackModule))
                {
                    attackModule.Update();
                }

                if (moduleController.TryGetModuleBase(typeof(ReloadModule), out ReloadModule reloadModule))
                {
                    reloadModule.Update();
                }
            }           
        }
    }

    public void SetWeaponFactory(WeaponFactory weaponFactory)
    {
        this.weaponFactory = weaponFactory;
    }
}
