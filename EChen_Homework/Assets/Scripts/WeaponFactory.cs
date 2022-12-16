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

    public List<WeaponComponent> GetAllProducts()
    {
        List<WeaponComponent> products = new List<WeaponComponent>();

        if(weapons.Values.Count <= 0)
        {
            Debug.LogError($"送你一個空集合");
            return products;
        }
        else
        {
            foreach (var weaponComponent in weapons.Values)
            {
                products.Add(weaponComponent);
            }
            return products;
        }
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        var products = GetAllProducts();
        if(products.Count <= 0)
        {
            Debug.LogError($"拿到一個空集合");
            return;
        }
        else
        {
            foreach (var weaponComponent in products)
            {
                weaponComponent.SetWeaponData(weaponData);
                Debug.LogError($"初始化武器資料:{weaponComponent.weaponData.weaponName}");
            }
           
        }
    }

}
