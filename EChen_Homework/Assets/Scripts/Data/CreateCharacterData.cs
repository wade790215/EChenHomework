using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "CreateModelData/CreateCharacterData")]
public class CreateCharacterData : ScriptableObject
{
    public CharacterData characterData;
}

[Serializable]
public class CharacterData 
{
    public string characterName;
    public float health;
}
