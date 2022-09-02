using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunWeapon
{
    Pistol,
    MachineGun,
    ShotGun,
    AssaultGun
}

public class WeaponController : MonoBehaviour
{
    public GunWeaponBase gun = null;
    public CreateWeaponData weaponData;
    public Transform firePoint;
    private InputModule inputModule;
    public GunWeapon weaponType;

    public void Start()
    {
        SetInputModule(new KeyboardInput());
        GetWeapon(weaponType);
    }   

    public void Update()
    {
        JudgementShottingMode();
        Reload();
    }

    public void SetInputModule(InputModule inputModule)
    {
        this.inputModule = inputModule; 
    }

    private void GetWeapon(GunWeapon getWeapon)
    {
        switch (getWeapon)
        {
            case GunWeapon.Pistol:
                gun = new GunWeaponBase(weaponData.WeaponData, firePoint, ShottingMode.SingleShot); 
                break;
            case GunWeapon.MachineGun:
                gun = new GunWeaponBase(weaponData.WeaponData, firePoint, ShottingMode.Auto);
                break;
            case GunWeapon.ShotGun:
                gun = new GunWeaponBase(weaponData.WeaponData, firePoint, ShottingMode.SingleShot);
                break;
            case GunWeapon.AssaultGun:
                gun = new GunWeaponBase(weaponData.WeaponData, firePoint, ShottingMode.Auto);
                break;
        }
    }
    
    private void JudgementShottingMode()
    {
        switch (gun.shottingMode)
        {
            case ShottingMode.SingleShot:
                //if (inputModule.PressDown(KeyCode.T))
                //{

                //}
                if (Input.GetKeyDown(KeyCode.A))
                {
                    gun.Attack();
                }
                break;

            case ShottingMode.Auto:
                //if (inputModule.PressAndHold())
                //{

                //}
                if (Input.GetKey(KeyCode.Space))
                {
                    gun.Attack();
                }
                break;
        }
    }

    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gun.Reload();
        }
    }   
}
