using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAttack : IAttack ,IGetWeaponData
{
    private WeaponData weaponData;
    private Transform firePoint;

    public SphereAttack(Transform firePoint)
    {       
        this.firePoint = firePoint;
    }


    public void DrawAttack()
    {
        //TODO �βy���I���Ӱ���
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }
}
