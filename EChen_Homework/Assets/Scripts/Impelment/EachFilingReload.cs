using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EachFilingReload : IReload, IGetWeaponData
{
    private WeaponData weaponData;
    public void Reload()
    {
        //TODO 逐顆裝填子彈
        Debug.Log($"逐顆裝填子彈");
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }
}
