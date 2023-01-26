using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : WeaponComponent
{
    private AttackModule attackModule;
    private ReloadModule reloadModule;

    public override ModuleController AssemblyComponent()
    {
        ModuleController moduleController = new ModuleController();
        attackModule = new AttackModule();
        reloadModule = new ReloadModule();        

        var rayAttack = new RayAttack();
        var fullReload = new FullReload();

        rayAttack.shottingMode = ShottingMode.AutoShot;

        attackModule.Init(rayAttack,weaponData,firePoint);
        reloadModule.Init(fullReload,weaponData);

        moduleController.AddModule(typeof(AttackModule), attackModule);
        moduleController.AddModule(typeof(ReloadModule), reloadModule);
        
        return moduleController;
    }
}
