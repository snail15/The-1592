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

    private UnitInfo _unit;
    
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
        _unit = unitInfoEventArgs.UnitInfo;
        var unitInfo = _unit.Info;

        portrait.GetComponent<Image>().sprite = _unit.Info.Portrait;
        nameText.text = $"이름: {unitInfo.Name}";
        hpText.text = $"HP: {unitInfo.HP}";
        mpText.text = $"MP: {unitInfo.MP}";
        levelText.text = $"LV: {unitInfo.Level}";
        if (unitInfoEventArgs.State != UnitState.Action)
            UpdateVisual(true);
        else
            UpdateVisual(false);
    }
    
    
    private void UpdateVisual(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
