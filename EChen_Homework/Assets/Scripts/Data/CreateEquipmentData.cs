using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentData", menuName = "CreateModelData/CreateEquipmentData")]
public class CreateEquipmentData : ScriptableObject
{
    public EquipmentData EquipmentData;
}

[Serializable]
public class EquipmentData 
{
    public string equipmentName;
    public string owner;
    public float defense;
    public float durability;
}

