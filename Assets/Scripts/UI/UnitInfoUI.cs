using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using TMPro;
using UnityEngine.UI;

public class UnitInfoUI : MonoBehaviour 
{
    [SerializeField] private Transform portrait;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI mpText;
    [SerializeField] private TextMeshProUGUI levelText;

    private UnitInfo _unitInfo;
    private Unit _unit;
    
    // Start is called before the first frame update
    private void Start()
    {
        UpdateVisual(false);
        MouseWorld.Instance.OnMouseOverUnit += OnMouseOverUnit;
        MouseWorld.Instance.OnMouseOutUnit += OnMouseOutUnit;
    }
    private void OnMouseOutUnit(object sender, MouseWorld.UnitInfoEventArgs unitInfoEventArgs)
    {
        UpdateVisual(false);
    }
    private void OnMouseOverUnit(object sender, MouseWorld.UnitInfoEventArgs unitInfoEventArgs)
    {
        _unitInfo = unitInfoEventArgs.UnitInfo;
        _unit = unitInfoEventArgs.Unit;
        
        portrait.GetComponent<Image>().sprite = _unitInfo.Info.Portrait;
        nameText.text = $"이름: {_unitInfo.Info.Name}";
        hpText.text = $"HP: {_unitInfo.Info.HP}";
        mpText.text = $"MP: {_unitInfo.Info.MP}";
        levelText.text = $"LV: {_unitInfo.Info.Level}";
        if (_unit != null && UnitStateManager.Instance.GetUnitState(_unit) != UnitState.Action)
            UpdateVisual(true);
        else
            UpdateVisual(false);
    }
    
    
    private void UpdateVisual(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
