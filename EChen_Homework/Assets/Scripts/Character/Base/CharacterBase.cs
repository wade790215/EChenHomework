using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase
{    
    public CharacterData characterData;
   
    public abstract void UnderAttack(CharacterBase attacker);
}

