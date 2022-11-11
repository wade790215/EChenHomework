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
    public GunWeaponBase gun;
    public CreateWeaponData weaponData;
    public Transform firePoint;  
    public GunWeapon weaponType; 
    
    private AttackModule attackModule;
    
    private void Start()
    {      
        GetWeapon(weaponType);
    }

    private void Update()
    {
        JudgementShottingMode();
        Reload();      
    }

    private void GetWeapon(GunWeapon getWeapon)
    {       
        switch (getWeapon)
        {
            case GunWeapon.Pistol:
                gun = new GunWeaponBase(ShottingMode.SingleShot);
                attackModule = new AttackModule(weaponData.WeaponData, firePoint);
                attackModule.SetAttack(new SphereAttack(weaponData.WeaponData, firePoint));
                gun.SetAttackModule(attackModule);
                break;

            case GunWeapon.MachineGun:
                gun = new GunWeaponBase(ShottingMode.Auto);
                attackModule = new AttackModule(weaponData.WeaponData, firePoint);
                attackModule.SetAttack(new RayAttack(weaponData.WeaponData, firePoint));
                gun.SetAttackModule(attackModule);
                break;

            case GunWeapon.ShotGun:
                gun = new GunWeaponBase(ShottingMode.SingleShot);
                attackModule = new AttackModule(weaponData.WeaponData, firePoint);
                attackModule.SetAttack(new RayAttack(weaponData.WeaponData, firePoint));
                gun.SetAttackModule(attackModule);
                break;

            case GunWeapon.AssaultGun:
                gun = new GunWeaponBase(ShottingMode.Auto);
                attackModule = new AttackModule(weaponData.WeaponData, firePoint);
                attackModule.SetAttack(new RayAttack(weaponData.WeaponData, firePoint));
                gun.SetAttackModule(attackModule);
                break;
        }
    }
    
    private void JudgementShottingMode()
    {
        switch (gun.shottingMode)
        {
            case ShottingMode.SingleShot:
                
                if (Input.GetKeyDown(KeyCode.A))
                {
                    gun.attackModule.Attack();
                }
                break;

            case ShottingMode.Auto:
               
                if (Input.GetKey(KeyCode.Space))
                {
                    gun.attackModule.Attack();
                }
                break;
        }
    }

    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gun.attackModule.Reload();
        }
    }
   
}
