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
        weaponFactory.SetWeaponData(weaponData.WeaponData);
        weaponFactory.TryGetWeaponComponent(weaponType, out myWeapon);
        //if (weaponFactory.TryGetWeaponComponent(weaponType, out WeaponComponent weapon))
        //{
        //    ModuleController moduleController = weapon.AssemblyComponent();


        //    Debug.Log(weapon.weaponData.weaponName);
        //}
    }

    public void OnUpdate()
    {
        //JudgementShottingMode();
        //Reload();      

        //    if (myWeapon != null)
        //    {
        //        ModuleController moduleController = myWeapon.AssemblyComponent();
        //        if(moduleController != null)
        //        {
        //            moduleController.Update();
        //        }

        //        ModuleController moduleController = myWeapon.AssemblyComponent();
        //        var modeList = moduleController.GetAllModuleBase();
        //        modeList.ForEach(p => p.Update());
        //    }
        //}

        //private void UseSkill()
        //{
        //    ModuleController moduleController = myWeapon.AssemblyComponent();
        //    if(moduleController.TryGetModuleBase(typeof(SkillModule), out SkillModule skillModule))
        //    {
        //        skillModule.Spell();
        //    }
        //}

        //private void JudgementShottingMode()
        //{


        //    switch (weapon..shottingMode)
        //    {
        //        case ShottingMode.SingleShot:

        //            if (Input.GetKeyDown(KeyCode.A))
        //            {
        //                weapon.attackModule.Attack();
        //            }
        //            break;

        //        case ShottingMode.Auto:

        //            if (Input.GetKey(KeyCode.Space))
        //            {
        //                gun.attackModule.Attack();
        //            }
        //            break;
        //    }
        //    //}

        //    //private void Reload()
        //    //{
        //    //    if (Input.GetKeyDown(KeyCode.R))
        //    //    {
        //    //        gun.reloadModule.Reload();
        //    //    }
        //    //}   
        //}
    }
}
