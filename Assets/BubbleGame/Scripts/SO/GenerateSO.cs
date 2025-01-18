using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GenerateSO", menuName = "GenerateSO")]
public class GenerateSO : ScriptableObject
{
    public GameObject prefab;
    public float distance = 100f;               // Distance between each prefab
}
