using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadModule : ModuleBase
{
    private IReload reload;

    public void SetReload(IReload reload)
    {
        this.reload = reload;   
    }

    public void Reload()
    {
        if(reload != null)
        {
            reload.Reload();
        }
    }

}
