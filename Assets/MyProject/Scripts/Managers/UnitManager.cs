using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnits> _units;
    private void Awake()
    {
        Instance = this;
        
        
    }
}
