using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory 
{
    private Dictionary<GunWeaponType,WeaponComponent> weapons = new Dictionary<GunWeaponType,WeaponComponent>();
      
    public void AddProductionLine(GunWeaponType gunWeapon, WeaponComponent weaponComponent)
    {
        if (weapons.ContainsKey(gunWeapon) == false)
        {
            weapons.Add(gunWeapon,weaponComponent);
            Debug.Log($"�s�W{gunWeapon}�Z�����\");
        }
        else
        {
            Debug.LogError($"�Ͳ��쭫�ƪ����O");
        }
    }

    public void RemoveProductionLine(GunWeaponType gunWeapon)
    {
        if (weapons.ContainsKey(gunWeapon))
        {
            weapons.Remove(gunWeapon);
        }
        else
        {
            Debug.LogError($"�L�k�����o��{gunWeapon}�F��");
        }
    }    

    public bool TryGetWeaponComponent<T>(GunWeaponType gunWeaponType, out T weaponComponent) where T : WeaponComponent
    {
        if (weapons.ContainsKey(gunWeaponType))
        {
            weaponComponent = (T)weapons[gunWeaponType];
            return true;
        }
        weaponComponent = default;
        return false;
    }   
}
