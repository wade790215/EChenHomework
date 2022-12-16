using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyFilingReload : ReloadBase
{  
    public override void Reload()
    {
        //TODO 能量充填
        Debug.Log($"目前能量:{weaponData.currentEnergy}");
    }
}
