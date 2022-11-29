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
    public GunWeapon weaponType;
    public GunWeaponBase gun;
    public CreateWeaponData weaponData;
    public Transform firePoint;  
    private ModuleController moduleController;
    private AttackModule attackModule;
    private ReloadModule reloadModule;
    private SphereAttack sphereAtk;
    private RayAttack rayAtk;
    private FullReload fullReload;
    private EnergyFilingReload energyReload;
    private List<IGetWeaponData> weaponDataList = new List<IGetWeaponData>();   

    private void Start()
    {
        CreateModule();
        CreateSkill();        
        GetWeapon(weaponType);
    }  

    private void Update()
    {
        JudgementShottingMode();
        Reload();      
    }

    private void CreateModule()
    {
        moduleController = new ModuleController();
        attackModule = new AttackModule(firePoint);
        reloadModule = new ReloadModule();
       
        moduleController.AddModule(attackModule.GetHashCode(), attackModule);
        moduleController.AddModule(reloadModule.GetHashCode(), reloadModule);
        moduleController.SetUpModulesData(weaponData.WeaponData);
    }

    private void CreateSkill()
    {
        sphereAtk = new SphereAttack(firePoint);
        rayAtk = new RayAttack(firePoint);

        fullReload = new FullReload();
        energyReload = new EnergyFilingReload();

        weaponDataList.Add(sphereAtk);
        weaponDataList.Add(rayAtk);
        weaponDataList.Add(fullReload);
        weaponDataList.Add(energyReload);

        foreach (var dataList in weaponDataList)
        {
            dataList.SetWeaponData(weaponData.WeaponData);
        }
    }

    private void GetWeapon(GunWeapon getWeapon)
    {       
        switch (getWeapon)
        {
            case GunWeapon.Pistol:
                gun = new GunWeaponBase(ShottingMode.SingleShot);                
                attackModule.SetAttack(rayAtk);
                reloadModule.SetReload(fullReload);
                gun.SetAttackModule(attackModule);
                gun.SetReloadModule(reloadModule);
                break;

            case GunWeapon.MachineGun:
                gun = new GunWeaponBase(ShottingMode.Auto);               
                attackModule.SetAttack(rayAtk);
                reloadModule.SetReload(fullReload);
                gun.SetAttackModule(attackModule);
                gun.SetReloadModule(reloadModule);
                break;

            case GunWeapon.ShotGun:
                gun = new GunWeaponBase(ShottingMode.SingleShot);               
                attackModule.SetAttack(sphereAtk);
                reloadModule.SetReload(fullReload);
                gun.SetAttackModule(attackModule);
                gun.SetReloadModule(reloadModule);
                break;

            case GunWeapon.AssaultGun:
                gun = new GunWeaponBase(ShottingMode.Auto);               
                attackModule.SetAttack(rayAtk);
                reloadModule.SetReload(energyReload);
                gun.SetAttackModule(attackModule);
                gun.SetReloadModule(reloadModule);
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
            gun.reloadModule.Reload();
        }
    }
   
}
