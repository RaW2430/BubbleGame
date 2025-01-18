using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    SmallBubble,
    SoapyWater,
    LargeCola,
    SmallCola,
    Sheild,
    OceanCurrent,
    Rock,
    Fish,
    SeaUrchin,
    BigFish,
    CheckPoint,
    Fountain,
}

[CreateAssetMenu(fileName = "GenerateSO", menuName = "GenerateSO")]
public class GenerateSO : ScriptableObject
{
    public GameObject prefab;
    public float distance = 100f;               // Distance between each prefab
    public ObjectType objectType;
}
