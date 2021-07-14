using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CommonTowerBuyUI : TowerBuyUI
{
    private void Awake()
    {
        _towerText = GetComponentInChildren<Text>();
        _towerText.text = _towerPrice.ToString();
    }

    public override int GetPrice()
    {
        return _towerPrice;
    }

    public override GameObject GetPrefab()
    {
        return _towerPrefab;
    }
}
