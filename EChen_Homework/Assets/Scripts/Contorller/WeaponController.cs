using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : ControllerBase
{
    private GunWeaponBase gun = null;

    public WeaponController(GunWeaponBase weaponBase, WeaponData weaponData)
    {
        InitWeapon(weaponBase, weaponData);
    }

    public override void OnStart()
    {

    }

    public override void OnUpdate()
    {
        switch (gun.gunShottingMode)
        {
            case ShottingMode.SingleShot:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    gun.Attack();
                }
                break;

            case ShottingMode.TripleShot:
                if (Input.GetKey(KeyCode.Space))
                {
                    gun.Attack();
                }
                break;

            case ShottingMode.Auto:
                break;

            default:
                break;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gun.Reload();
        }
    }

    public void InitWeapon(GunWeaponBase weaponBase, WeaponData weaponData)
    {
        gun = weaponBase;
        gun.WeaponData = weaponData;
    }
}
