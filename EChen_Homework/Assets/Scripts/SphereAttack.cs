using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAttack : IAttack
{
    private WeaponData weaponData;
    private Transform firePoint;

    public SphereAttack(WeaponData weaponData, Transform firePoint)
    {
        this.weaponData = weaponData;
        this.firePoint = firePoint;
    }


    public void DrawAttack()
    {
        //TODO 用球型碰撞來偵測
    }
}
