using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    private WeaponData pistolData;
    private WeaponData machineGunData;
    private Pistol pistol;
    private MachineGun machineGun;
    private WeaponController pistolController;
    private WeaponController machineGunController;
    private List<ControllerBase> controllerList = new List<ControllerBase>();    

    void Start()
    {
        pistolData = new WeaponData();
        pistolData.weaponName = "Pistol";
        pistolData.maxBulletCount = 10;
        pistolData.currentBulletCount = pistolData.maxBulletCount;
        pistolData.attackRate = 1f;

        machineGunData = new WeaponData();
        machineGunData.weaponName = "MachineGun";
        machineGunData.maxBulletCount = 100;
        machineGunData.currentBulletCount = machineGunData.maxBulletCount;
        machineGunData.attackRate = 4f;

        pistol = new Pistol(ShottingMode.SingleShot);     
        machineGun = new MachineGun(ShottingMode.TripleShot);

        pistolController = new WeaponController(pistol, pistolData);
        machineGunController = new WeaponController(machineGun, machineGunData);

        controllerList.Add(pistolController);
        controllerList.Add(machineGunController);

        foreach (var item in controllerList)
        {
            item.OnStart(); 
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in controllerList)
        {
            item.OnUpdate();
        }
    }
}
