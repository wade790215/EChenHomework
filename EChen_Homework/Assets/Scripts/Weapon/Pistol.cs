using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class Pistol : GunWeaponBase
{
    public Pistol(ShottingMode shottingMode, WeaponData weaponData) : base(shottingMode, weaponData)
    {
    }

    public override void Attack(CharacterBase character)
    {
       
    }
}
