using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyFilingReload : IReload,IGetWeaponData
{
    private WeaponData weaponData;  

    public void Reload()
    {
        //TODO 能量充填
        Debug.Log($"目前能量:{weaponData.currentEnergy}");
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;   
    }
}
