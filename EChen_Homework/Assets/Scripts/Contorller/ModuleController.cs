using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleController
{   
    private Dictionary<Type, ModuleBase> modules = new Dictionary<Type, ModuleBase>();

    public void AddModule(Type hashCode, ModuleBase module)
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

    public void RemoveModule(Type hashCode)
    {
        if (modules.ContainsKey(hashCode))
        {
            modules.Remove(hashCode);
        }       
    }

    public bool TryGetModuleBase(Type hashCode,out ModuleBase moduleBase)
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

    public bool TryGetModuleBase<T>(Type hashCode, out T module) where T : ModuleBase
    {
        if (modules.ContainsKey(hashCode))
        {
            module = (T)modules[hashCode];
            return true;
        }
        module = default;
        return false;
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
