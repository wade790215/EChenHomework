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

public class WeaponController : ControllerBase
{
    public GunWeaponBase gun = null;
    public CreateWeaponData weaponData;  
    public ShottingMode shottingMode;
    public GunWeapon getWeapon;

    public override void OnStart()
    {
        
    }

    public override void OnUpdate()
    {
        
    }

    public void Start()
    {
        GetWeapon(getWeapon);
    }   

    public void Update()
    {
        JudgementShottingMode();
        Reload();
    }

    private void GetWeapon(GunWeapon getWeapon)
    {
        switch (getWeapon)
        {
            case GunWeapon.Pistol:
                gun = new Pistol(shottingMode, GetWeaponData(weaponData.WeaponData));
                break;
            case GunWeapon.MachineGun:
                gun = new MachineGun(shottingMode, GetWeaponData(weaponData.WeaponData));
                break;
            case GunWeapon.ShotGun:
                gun = new ShotGun(shottingMode, GetWeaponData(weaponData.WeaponData));
                break;
            case GunWeapon.AssaultGun:
                gun = new AssaultGun(shottingMode, GetWeaponData(weaponData.WeaponData));
                break;
        }
    }

    private WeaponData GetWeaponData(List<WeaponData> weaponData)
    {
        return weaponData.Find((gun) => gun.weaponName == getWeapon);
    }

    private void JudgementShottingMode()
    {
        switch (gun.gunShottingMode)
        {
            case ShottingMode.SingleShot:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    gun.Attack();
                }
                break;

            case ShottingMode.Auto:
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
