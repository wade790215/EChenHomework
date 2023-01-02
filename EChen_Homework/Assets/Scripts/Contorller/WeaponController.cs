using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunWeaponType
{
    Pistol,
    MachineGun,
    ShotGun,
    AssaultGun
}

public class SkillBase
{

}

public class SkillModule : ModuleBase
{
    //public void Set

    //internal void Spell()
    //{
    //    throw new NotImplementedException();
    //}
}

public class WeaponController : MonoBehaviour
{
    public GunWeaponType weaponType;
    public CreateWeaponData weaponData;
    public Transform firePoint;
    public Pistol weapon;
    private WeaponFactory weaponFactory;
    private WeaponComponent myWeapon;

    private void Awake()
    {
        weaponData.WeaponData.firePoint = firePoint.transform;
    }

    public void SetWeaponFactory(WeaponFactory weaponFactory)
    {
        this.weaponFactory = weaponFactory;
    }

    public void OnStart()
    {       
        if(weaponFactory.TryGetWeaponComponent(weaponType, out  WeaponComponent myWeapon))
        {
            this.myWeapon = myWeapon;
            this.myWeapon.SetWeaponData(weaponData.WeaponData);
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
}
