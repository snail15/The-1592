using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Unit", fileName = "New Unit")]
public class UnitSo : ScriptableObject 
{

    public string Name;
    public Transform Prefab;
    public Sprite Portrait;
    public int Level;
    public int HP;
    public int MP;
    
}
