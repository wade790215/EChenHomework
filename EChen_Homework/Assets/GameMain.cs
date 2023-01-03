using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    private WeaponFactory weaponFactory;
    private WeaponController[] weaponController;

    [Serializable]
    public class Test 
    {
        public int HP;
        public string Name;  
        public int[] Level = new int[] {1,2,3};
    }

    public class TestPath : IDataPath
    {
        public string GetDataPath()
        {
            return "TestPath";
        }
    }

    private void Start()
    {
        var FH = new FileHandler();
        List<Test> tests = new List<Test>();
        var test1 =new Test() { HP = 100, Name = "Wade", Level = new int[] { 33, 66 } };
        var test2 =new Test() { HP = 999, Name = "Cindy", Level = new int[] { 99, 111} };
        tests.Add(test1);
        tests.Add(test2);
       

        weaponFactory = new WeaponFactory();
        weaponFactory.AddProductionLine(GunWeaponType.Pistol, new Pistol());
        weaponFactory.AddProductionLine(GunWeaponType.MachineGun, new MachineGun());
        weaponFactory.AddProductionLine(GunWeaponType.AssaultGun, new AssaultGun());
        weaponFactory.AddProductionLine(GunWeaponType.ShotGun, new ShotGun());

        weaponController = FindObjectsOfType<WeaponController>(true);
        
        foreach (var controller in weaponController)
        {
            controller.SetWeaponFactory(weaponFactory);            
        }

        foreach (var controller in weaponController)
        {
            controller.OnStart();
        }
    }

    
    private void Update()
    {
        foreach (var controller in weaponController)
        {
            controller.OnUpdate();
        }
    }
}
