using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleController
{
    private Dictionary<int,ModuleBase> modules = new Dictionary<int,ModuleBase>();  

    public void AddModule(int hashCode, ModuleBase module)
    {
        if (modules.ContainsKey(hashCode) == false)
        {
            modules.Add(hashCode, module);
        }
        else
        {
            Debug.Log($"已經有加過:{module}");
        }
    }

    public void RemoveModule(int hashCode)
    {
        if (modules.ContainsKey(hashCode))
        {
            modules.Remove(hashCode);
        }       
    }

    public bool TryGetModuleBase(int hashCode,out ModuleBase moduleBase)
    {
        if (modules.TryGetValue(hashCode, out ModuleBase module))
        {
            moduleBase = module;    
            return true;
        }
        else
        {
            moduleBase = null;
            return false;   
        }        
    }

    public List<ModuleBase> GetAllModuleBase()
    {
        List<ModuleBase> cacheModuleBase = new List<ModuleBase>();

        foreach (var moduleBase in modules.Values)
        {
            cacheModuleBase.Add(moduleBase);    
        }

        return cacheModuleBase;
    }

    public void SetUpModulesData(WeaponData weaponData)
    {
        if(modules.Count > 0)
        {
            foreach (var module in modules.Values)
            {
                module.SetUpWeaponData(weaponData);
            }
        }       
    }
}
