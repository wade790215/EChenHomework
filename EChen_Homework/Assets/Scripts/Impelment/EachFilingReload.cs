using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EachFilingReload : IReload, IGetWeaponData
{
    private WeaponData weaponData;
    public void Reload()
    {
        //TODO �v���˶�l�u
        Debug.Log($"�v���˶�l�u");
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }
}
