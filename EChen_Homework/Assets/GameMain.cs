using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    private WeaponFactory weaponFactory;
    private WeaponController[] weaponController;

    private void Start()
    {
        weaponFactory = new WeaponFactory();
        weaponFactory.AddProductionLine(GunWeaponType.Pistol, new Pistol());
        weaponFactory.AddProductionLine(GunWeaponType.MachineGun, new MachineGun());
        weaponFactory.AddProductionLine(GunWeaponType.AssaultGun, new AssaultGun());
        weaponFactory.AddProductionLine(GunWeaponType.ShotGun, new ShotGun());

        weaponController = FindObjectsOfType<WeaponController>(true);
        weaponFactory.AssemblyWeaponComponent();
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
}
