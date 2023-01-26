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
   
    public void OnStart()
    {       
        if(weaponFactory.TryGetWeaponComponent(weaponType, out WeaponComponent myWeapon))
        {
            this.myWeapon = myWeapon;
            this.myWeapon.SetFirePoint(firePoint);   
        }     
    }

    public void OnUpdate()
    {
        if (myWeapon != null)
        {
            ModuleController moduleController = myWeapon.AssemblyComponent();
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
