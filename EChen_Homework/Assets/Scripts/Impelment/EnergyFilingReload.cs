using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyFilingReload : IReload,IGetWeaponData
{
    private WeaponData weaponData;  

    public void Reload()
    {
        //TODO ��q�R��
        Debug.Log($"�ثe��q:{weaponData.currentEnergy}");
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;   
    }
}
