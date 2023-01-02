using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultGun : WeaponComponent
{    
    public override ModuleController AssemblyComponent()
    {
        ModuleController moduleController = new ModuleController();
        var attackModule = new AttackModule();
        var reloadModule = new ReloadModule();
        var rayAttack = new RayAttack();
        var fullReload = new FullReload();

        rayAttack.shottingMode = ShottingMode.TripleShot;

        attackModule.Init(rayAttack,weaponData);
        reloadModule.Init(fullReload,weaponData);

        moduleController.AddModule(typeof(AttackModule), attackModule);
        moduleController.AddModule(typeof(ReloadModule), reloadModule);       

        return moduleController;
    }
}
