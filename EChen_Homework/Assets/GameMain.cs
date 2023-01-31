using System;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    private WeaponFactory weaponFactory;
    private WeaponController[] weaponController;
    private FileHandler fileHandler;
    private List<WeaponData> weapons;

    private void Awake()
    {
        fileHandler = new FileHandler();
        weaponFactory = new WeaponFactory();
        weapons = fileHandler.ReadListFromJSON<WeaponData>();
    }

    private void Start()
    {
        CreateProductionLine();

        weaponController = FindObjectsOfType<WeaponController>(true);

        foreach (var controller in weaponController)
        {
            controller.SetWeaponFactory(weaponFactory);
        }

        foreach (var controller in weaponController)
        {
            controller.OnStart();
        }
    }

    private void Update()
    {
        foreach (var controller in weaponController)
        {
            controller.OnUpdate();
        }
    }

    /// <summary>
    /// 只負責製造產品線，實際組裝功能由Weaponcontroller實作並生產
    /// </summary>
    private void CreateProductionLine()
    {
        foreach (var weapon in weapons)
        {
            switch (weapon.weaponType)
            {
                case GunWeaponType.Pistol:
                    var pistol = new Pistol();
                    pistol.SetWeaponData(weapon);
                    weaponFactory.AddProductionLine(GunWeaponType.Pistol, pistol);
                    break;
                case GunWeaponType.MachineGun:
                    var machineGun = new MachineGun();
                    machineGun.SetWeaponData(weapon);
                    weaponFactory.AddProductionLine(GunWeaponType.MachineGun, machineGun);
                    break;
                case GunWeaponType.ShotGun:
                    var shotGun = new ShotGun();
                    shotGun.SetWeaponData(weapon);
                    weaponFactory.AddProductionLine(GunWeaponType.ShotGun, shotGun);
                    break;
                case GunWeaponType.AssaultGun:
                    var assaultGun = new AssaultGun();
                    assaultGun.SetWeaponData(weapon);
                    weaponFactory.AddProductionLine(GunWeaponType.AssaultGun, assaultGun);
                    break;
            }
        }
    }  
}
