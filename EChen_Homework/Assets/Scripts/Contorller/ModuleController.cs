using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleController
{   
    private Dictionary<Type, ModuleBase> modules = new Dictionary<Type, ModuleBase>();

    public void AddModule(Type type, ModuleBase module)
    {
        if (modules.ContainsKey(type) == false)
        {
            modules.Add(type, module);
        }
        else
        {
            Debug.Log($"已經有加過:{module}");
        }
    }

    public void RemoveModule(Type type)
    {
        if (modules.ContainsKey(type))
        {
            modules.Remove(type);
        }       
    }  

    public bool TryGetModuleBase<T>(Type type, out T module) where T : ModuleBase
    {
        if (modules.ContainsKey(type))
        {
            module = (T)modules[type];
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
 
}
