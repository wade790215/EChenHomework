using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "CreateModelData/CreateCharacterData")]
public class CreateCharacterData : ScriptableObject
{
    public List<CharacterData> characterData = new List<CharacterData>();
}

[Serializable]
public class CharacterData : DataBase
{
    public string characterName;
    public float health;
}
