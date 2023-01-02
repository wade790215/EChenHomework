using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : WeaponComponent
{   
    public override ModuleController AssemblyComponent()
    {
        ModuleController moduleController = new ModuleController();
        var attackModule = new AttackModule();
        var reloadModule = new ReloadModule();
        var sphereAttack = new SphereAttack();
        var eachReload = new EachFilingReload();

        attackModule.Init(sphereAttack,weaponData);
        reloadModule.Init(eachReload, weaponData);       

        moduleController.AddModule(typeof(AttackModule), attackModule);
        moduleController.AddModule(typeof(ReloadModule), reloadModule);        

        return moduleController;
    }
}
