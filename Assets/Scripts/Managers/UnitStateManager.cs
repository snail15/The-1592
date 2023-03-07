using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class UnitStateManager : Singleton<UnitStateManager>
{
    private Dictionary<BaseUnit, UnitState> _unitStates;
    
    protected override void Awake()
    {
        base.Awake();
        _unitStates = new Dictionary<BaseUnit, UnitState>();
    }
    
    public UnitState GetUnitState(BaseUnit unit)
    {
        return _unitStates[unit];
    }

    public void SetUnitState(BaseUnit unit, UnitState state)
    {
        _unitStates[unit] = state;
        Debug.Log($"{unit.name} State: {state.ToString()}");
    }
    

}
