using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : CharacterBase
{    
    public override void UnderAttack(CharacterBase attacker)
    {
        Debug.Log(attacker);    
    }
}
