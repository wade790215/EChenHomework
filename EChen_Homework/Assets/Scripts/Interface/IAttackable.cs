using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{   
    public void Attack(IAttackable attakcer);
    public void SetWeapon(GunWeaponBase weapon);   
}
   

