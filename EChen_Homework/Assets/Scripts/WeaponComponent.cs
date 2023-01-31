using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline.Tasks;
using UnityEngine;

/// <summary>
/// 提供組裝武器的類別
/// </summary>
/// <returns></returns>
public class WeaponComponent:IGetWeaponData
{
    public WeaponData weaponData { get; private set;}

    protected Transform firePoint;

    public virtual ModuleController AssemblyComponent() { return new ModuleController(); }

    public ModuleController AssemblyComponentFromSetting() 
    {
        var moduleController = new ModuleController();
        var attackModule = new AttackModule();
        var reloadModule = new ReloadModule();
        RayAttack rayAttack = default;
        SphereAttack sphereAttack = default;
        EachFilingReload eachFilingReload = default;
        FullReload fullReload = default;
        
        switch (weaponData.detectingType)
        {
            case DetectingType.Ray:
                rayAttack = new RayAttack(weaponData.shottingMode);
                attackModule.Init(rayAttack, weaponData, firePoint);
                break;
            case DetectingType.Sphere:
                sphereAttack = new SphereAttack(weaponData.shottingMode);
                attackModule.Init(sphereAttack, weaponData, firePoint);
                break;        
        }

        switch (weaponData.reloadingType)
        {
            case ReloadingType.EachFiling:
                eachFilingReload = new EachFilingReload();
                reloadModule.Init(eachFilingReload, weaponData);
                break;
            case ReloadingType.Full:
                fullReload = new FullReload();
                reloadModule.Init(fullReload, weaponData);
                break;           
        }        

        moduleController.AddModule(typeof(AttackModule), attackModule);
        moduleController.AddModule(typeof(ReloadModule), reloadModule);

        return moduleController;
    }    

    public void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }    

    public void SetFirePoint(Transform firePoint)
    {
        this.firePoint = firePoint;
    }
}
