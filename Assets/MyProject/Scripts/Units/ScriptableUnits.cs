using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptables/Scriptable Unit")]
public class ScriptableUnits : ScriptableObject
{

    public Faction faction;
    public BaseUnit unitPrefab;
    
}

public enum Faction
{
    Player = 0,
    Enemy = 1
}