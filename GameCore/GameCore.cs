using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    private MainUI _mainUI;
    private Map _map;
    private RoundManager _round;

    private void Awake()
    {
        _mainUI = GetComponent<MainUI>();
        _round = GetComponent<RoundManager>();

        _map = FindObjectOfType<Map>();

        StartGame();
    }

    //---------------------------------------------------------
    //MainUI
    public void EnableBuyUI(int x, int z)
    {
        _mainUI.EnableBuyUI(x, z);
    }
    public void DisableBuyUI()
    {
        _mainUI.DisableBuyUI();
    }

    public void AddMoney(int value)
    {
        _mainUI.AddMoney(value);
    }
    public void SpendMoney(int value)
    {
        _mainUI.SpendMoney(value);
    }
    public bool IsEnoughtMoney(int value)
    {
        return _mainUI.IsEnoughMoney(value);
    }

    public void IncreaseProgress(float value)
    {
        _mainUI.IncreaseProgress(value);
    }

    //---------------------------------------------------------
    //Map
    public void PlaceTower(int x, int z, GameObject prefab)
    {
        _map.PlaceMapUnit(x,z,prefab);
    }
    public void SpawnEnemy(int amount, GameObject _enemyPrefab, Vector3 target)
    {
        _map.SpawnEnemy(amount, _enemyPrefab, target);
    }
    public Dictionary<GameObject, List<Edge>> GetGraph()
    {
        return _map.GetGraph();
    }
    public List<GameObject> GetVertexes()
    {
        return _map.GetVertexes();
    }
    public void DeleteBase()
    {
        _map.DeleteBase();
    }

    //---------------------------------------------------------
    //RoundManager
    public Vector3 GetEnemyTarget(int number)
    {
        return _round.GetEnemyTarget(number);
    }
    public void DeleteEnemy(GameObject enemy)
    {
        _round.DeleteEnemy(enemy);
    }

    public bool IsInPath(GameObject vertex)
    {
        return _round.IsInPath(vertex);
    }

    //---------------------------------------------------------
    //GameCore
    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }
    private IEnumerator StartGameCoroutine()
    {
        yield return new WaitForSeconds(2);
        _round.CreateWay();
        yield return new WaitForSeconds(2);
        _map.PrintRoad();
        yield return new WaitForSeconds(3);
        _round.Enemies = _map.SpawnEnemy(_round.GetAmountEnemies(), _round.GetEnemyPrefab(), _round.GetEnemyTarget());
        _round.StartWaitingEndRound();
    }

    public void StartNewRound()
    {
        StartCoroutine(NewRoundCoroutine());
    }
    private IEnumerator NewRoundCoroutine()
    {
        DeleteRoads();
        yield return new WaitForSeconds(2);
        _map.RemakeGraph();
        yield return new WaitForSeconds(2);
        _round.CreateWay();
        yield return new WaitForSeconds(3);
        _map.PrintRoad();
        yield return new WaitForSeconds(3);
        _round.Enemies = _map.SpawnEnemy(_round.GetAmountEnemies(), _round.GetEnemyPrefab(), _round.GetEnemyTarget());
        _round.StartWaitingEndRound();
    }
    private void DeleteRoads()
    {
        GameObject[] roads = GameObject.FindGameObjectsWithTag("road");
        for (int i = 0; i < roads.Length; i++)
        {
            Destroy(roads[i]);
        }
    }

    public void StopGame()
    {
        StopAllCoroutines();
        _round.StopGame();
        _mainUI.EnableRoundUI();
        _mainUI.SetRound(_round.GetRounds());
    }
}
