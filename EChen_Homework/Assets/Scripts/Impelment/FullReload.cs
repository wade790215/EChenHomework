using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullReload : IReload,IGetWeaponData
{
    private WeaponData weaponData;
    
    public void Reload()
    {
        if (weaponData.currentBulletCount == weaponData.maxBulletCount)
        {
            Debug.Log($"{weaponData.weaponName} + Magazine is full.");
            return;
        }

        weaponData.currentBulletCount = weaponData.maxBulletCount;
        Debug.Log($"{weaponData.weaponName} + Reloaded");
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }
}
