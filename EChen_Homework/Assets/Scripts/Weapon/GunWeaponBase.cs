using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShottingMode
{
    SingleShot,
    Auto
}

public class GunWeaponBase
{  
    public ShottingMode shottingMode;
    public WeaponData WeaponData;
    public AttackModule attackModule;

    public GunWeaponBase(ShottingMode shottingMode)
    {           
        this.shottingMode = shottingMode;
    }   
   
    public void SetAttackModule(AttackModule attackModule)
    {
        this.attackModule = attackModule;    
    }       
}




