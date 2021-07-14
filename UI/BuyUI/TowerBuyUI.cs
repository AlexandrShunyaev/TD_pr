using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TowerBuyUI : MonoBehaviour
{
    [SerializeField] protected GameObject _towerPrefab;
    [SerializeField] protected int _towerPrice;
    protected Text _towerText;

    public abstract int GetPrice();
    public abstract GameObject GetPrefab();
}
