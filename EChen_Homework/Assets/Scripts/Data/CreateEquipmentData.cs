using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentData", menuName = "CreateModelData/CreateEquipmentData")]
public class CreateEquipmentData : ScriptableObject
{
    public List<EquipmentData> EquipmentData = new List<EquipmentData>();
}

[Serializable]
public class EquipmentData : DataBase
{
    public string equipmentName;
    public string owner;
    public float defense;
    public float durability;
}

