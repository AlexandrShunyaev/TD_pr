using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUI : MonoBehaviour
{
    private CommonTowerBuyUI _commonTower;
    private FireTowerBuyUI _fireTower;
    private WaterTowerBuyUI _waterTower;
    private EarthTowerBuyUI _earthTower;

    private GameCore _core;

    private int _x;
    private int _z;

    private void Awake()
    {
        _core = FindObjectOfType<GameCore>();

        _commonTower = GetComponentInChildren<CommonTowerBuyUI>();
        _fireTower = GetComponentInChildren<FireTowerBuyUI>();
        _waterTower = GetComponentInChildren<WaterTowerBuyUI>();
        _earthTower = GetComponentInChildren<EarthTowerBuyUI>();
    }

    public void SetPosition(int x, int z)
    {
        _x = x;
        _z = z;
    }
    
    public void PlaceCommonTower()
    {
        if (_core.IsEnoughtMoney(_commonTower.GetPrice()))
        {
            _core.SpendMoney(_commonTower.GetPrice());
            _core.PlaceTower(_x, _z, _commonTower.GetPrefab());
            _core.DisableBuyUI();
        }
        else
        {
            Debug.Log("Not enough money!");
            _core.DisableBuyUI();
        }
    }
    public void PlaceFireTower()
    {
        if (_core.IsEnoughtMoney(_fireTower.GetPrice()))
        {
            _core.SpendMoney(_fireTower.GetPrice());
            _core.PlaceTower(_x, _z, _fireTower.GetPrefab());
            _core.DisableBuyUI();
        }
        else
        {
            Debug.Log("Not enough money!");
            _core.DisableBuyUI();
        }
    }
    public void PlaceWaterTower()
    {
        if (_core.IsEnoughtMoney(_waterTower.GetPrice()))
        {
            _core.SpendMoney(_waterTower.GetPrice());
            _core.PlaceTower(_x, _z, _waterTower.GetPrefab());
            _core.DisableBuyUI();
        }
        else
        {
            Debug.Log("Not enough money!");
            _core.DisableBuyUI();
        }
    }
    public void PlaceEarthTower()
    {
        if (_core.IsEnoughtMoney(_earthTower.GetPrice()))
        {
            _core.SpendMoney(_earthTower.GetPrice());
            _core.PlaceTower(_x, _z, _earthTower.GetPrefab());
            _core.DisableBuyUI();
        }
        else
        {
            Debug.Log("Not enough money!");
            _core.DisableBuyUI();
        }
    }

    public void CloseBuyUI()
    {
        _core.DisableBuyUI();
    }
}
