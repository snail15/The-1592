using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnit : MonoBehaviour
{
   public UnitState UnitState;

   protected virtual void Awake()
   {
      UnitState = UnitState.Active;
   }

   protected virtual void Start()
   {
      UnitStateManager.Instance.SetUnitState(this, UnitState.Active);
   }
}
