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
            Debug.Log($"新增{gunWeapon}武器成功");
        }
        else
        {
            Debug.LogError($"生產到重複的類別");
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
            Debug.LogError($"無法移除這個{gunWeapon}東西");
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
