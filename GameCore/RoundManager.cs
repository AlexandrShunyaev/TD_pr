using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private int _amountEnemies;
    [SerializeField] private GameObject _enemyPrefab;
    private int _roundsCounter = 1;

    private GameCore _core;
    
    public List<GameObject> Enemies;
    private List<GameObject> _way;


    private void Awake()
    {
        _core = GetComponent<GameCore>();

        Enemies = new List<GameObject>();
        _way = new List<GameObject>();
    }

    public void StartWaitingEndRound()
    {
        StartCoroutine(WaitEndRoundCoroutine());
    }
    private IEnumerator WaitEndRoundCoroutine()
    {
        while(Enemies.Count > 0)
        {
            yield return new WaitForEndOfFrame();
        }
        ++_roundsCounter;
        _amountEnemies += 10;
        _core.IncreaseProgress(0f);
        _core.DeleteBase();
        _way = new List<GameObject>();
        Enemies = new List<GameObject>();
        _core.StartNewRound();
        
    }

    public void CreateWay()
    {
        Dijkstra way = new Dijkstra(_core.GetGraph(), _core.GetVertexes());
        way.Algorithm();
        _way = way.GetAnswer();
    }

    public int GetAmountEnemies()
    {
        return _amountEnemies;
    }
    public GameObject GetEnemyPrefab()
    {
        return _enemyPrefab;
    }
    public Vector3 GetEnemyTarget(int number = 1)
    {
        return _way[number].transform.position;
    }
    public int GetRounds()
    {
        return _roundsCounter;
    }

    public bool IsInPath(GameObject vertex)
        {
            foreach (var vertex2 in _way)
            {
                if (vertex2 == vertex)
                {
                    return true;
                }
            }
            return false;
        }
    public void DeleteEnemy(GameObject enemy)
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if(Enemies[i] == enemy)
            {
                Enemies.RemoveAt(i);
                break;
            }
        }
        _core.IncreaseProgress((1.0f/(float)_amountEnemies));
    }

    public void StopGame()
    {
        StopAllCoroutines();
    }

}
