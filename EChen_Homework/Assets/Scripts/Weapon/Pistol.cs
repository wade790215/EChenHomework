using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponComponent
{
    private AttackModule attackModule;
    private ReloadModule reloadModule;

    public override ModuleController AssemblyComponent()
    {
        ModuleController moduleController = new ModuleController();
        attackModule = new AttackModule();
        reloadModule = new ReloadModule();

        moduleController.AddModule(typeof(AttackModule), attackModule);
        moduleController.AddModule(typeof(ReloadModule), reloadModule);
        return moduleController;
    }
}
