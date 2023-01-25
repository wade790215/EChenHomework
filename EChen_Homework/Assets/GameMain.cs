using System;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    private WeaponFactory weaponFactory;
    private WeaponController[] weaponController;
    private FileHandler fileHandler;
    private List<WeaponInfo> weapons;   

    private void Awake()
    {
        fileHandler = new FileHandler();
        weaponFactory = new WeaponFactory();
        weapons = fileHandler.ReadListFromJSON<WeaponInfo>();
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

    private void CreateProductionLine()
    {
        foreach (var weapon in weapons)
        {
            switch (weapon.weaponType)
            {
                case GunWeaponType.Pistol:
                    weaponFactory.AddProductionLine(GunWeaponType.Pistol, new Pistol());
                    break;
                case GunWeaponType.MachineGun:
                    weaponFactory.AddProductionLine(GunWeaponType.MachineGun, new MachineGun());
                    break;
                case GunWeaponType.ShotGun:
                    weaponFactory.AddProductionLine(GunWeaponType.ShotGun, new ShotGun());
                    break;
                case GunWeaponType.AssaultGun:
                    weaponFactory.AddProductionLine(GunWeaponType.AssaultGun, new AssaultGun());
                    break;
            }
        }
    }

    private void Update()
    {
        foreach (var controller in weaponController)
        {
            controller.OnUpdate();
        }
    }
}
