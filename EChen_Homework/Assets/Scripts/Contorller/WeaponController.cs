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
    public GunWeapon weaponType;

    public void Start()
    {
        GetWeapon(weaponType);
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
                gun = new GunWeaponBase(GetWeaponData(weaponData.WeaponData), firePoint, ShottingMode.SingleShot); 
                break;
            case GunWeapon.MachineGun:
                gun = new GunWeaponBase(GetWeaponData(weaponData.WeaponData), firePoint, ShottingMode.Auto);
                break;
            case GunWeapon.ShotGun:
                gun = new GunWeaponBase(GetWeaponData(weaponData.WeaponData), firePoint, ShottingMode.SingleShot);
                break;
            case GunWeapon.AssaultGun:
                gun = new GunWeaponBase(GetWeaponData(weaponData.WeaponData), firePoint, ShottingMode.Auto);
                break;
        }
    }

    private WeaponData GetWeaponData(List<WeaponData> weaponData)
    {
        return weaponData.Find((gun) => gun.weaponName == weaponType);
    }

    private void JudgementShottingMode()
    {
        switch (gun.shottingMode)
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
