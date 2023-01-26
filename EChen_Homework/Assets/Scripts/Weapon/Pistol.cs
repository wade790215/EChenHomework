using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponComponent
{   
    public override ModuleController AssemblyComponent()
    {
        var moduleController = new ModuleController();
        var attackModule = new AttackModule();
        var reloadModule = new ReloadModule();
        var rayAttack = new RayAttack();
        var fullReload = new FullReload();

        rayAttack.shottingMode = ShottingMode.SingleShot;
        attackModule.Init(rayAttack,weaponData,firePoint);
        reloadModule.Init(fullReload,weaponData);

        moduleController.AddModule(typeof(AttackModule), attackModule);
        moduleController.AddModule(typeof(ReloadModule), reloadModule);             
        
        return moduleController;
    }  
}
