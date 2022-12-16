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

public class WeaponController : MonoBehaviour
{
    public GunWeaponType weaponType;    
    public CreateWeaponData weaponData;
    public Transform firePoint;      
    private WeaponFactory weaponFactory;

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
        if (weaponFactory.TryGetWeaponComponent(weaponType, out Pistol pistol))
        {
            Debug.Log(pistol.weaponData.weaponName);
        }
    }  
   
    public void OnUpdate()
    {
        //JudgementShottingMode();
        //Reload();      
    }      
    
    //private void JudgementShottingMode()
    //{
    //    switch (gun.shottingMode)
    //    {
    //        case ShottingMode.SingleShot:
                
    //            if (Input.GetKeyDown(KeyCode.A))
    //            {
    //                gun.attackModule.Attack();
    //            }
    //            break;

    //        case ShottingMode.Auto:
               
    //            if (Input.GetKey(KeyCode.Space))
    //            {
    //                gun.attackModule.Attack();
    //            }
    //            break;
    //    }
    //}

    //private void Reload()
    //{
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        gun.reloadModule.Reload();
    //    }
    //}   
}
