using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        
        //TODO Switch改用反射來做
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



//[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
//sealed class NameAttribute : System.Attribute
//{
//    public string Name { get; private set; }

//    // See the attribute guidelines at 
//    //  http://go.microsoft.com/fwlink/?LinkId=85236
//    readonly string positionalString;

//    // This is a positional argument
//    public NameAttribute(string name)
//    {
//        this.Name = name;
//    }
//}

//public class NameHandler
//{
//    public List<string> GetAllNameClass()
//    {
//        var allType = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
//        foreach (var type in allType)
//        {
//            var nameAttributes = type.GetCustomAttributes<NameAttribute>(false);
//            if (nameAttributes.Count() > 0)
//            {
//                //add all class name to list
//                List<string> names = new List<string>();

//                //foreach nameAttribute
//                foreach (var name in nameAttributes)
//                {
//                    //add
//                    names.Add(name.Name);
//                }
//            }
//        }
//    }

//    public List<(string, A)> GetAllOptions()
//    {
//        List<(string, A)> options = new List<(string, A)>();

//        options.Add((typeof(A).Name, new A()));
//    }
//}

//[Name("連續射擊")]
//public class A
//{
    
//}

//public interface ICreater
//{
//    A Create(object[] args);
//}