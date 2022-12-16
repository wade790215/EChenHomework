using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullReload : ReloadBase
{   
    public override void Reload()
    {
        if (weaponData.currentBulletCount == weaponData.maxBulletCount)
        {
            Debug.Log($"{weaponData.weaponName} + Magazine is full.");
            return;
        }

        weaponData.currentBulletCount = weaponData.maxBulletCount;
        Debug.Log($"{weaponData.weaponName} + Reloaded");
    }  
}
