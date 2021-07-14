using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private GameObject _mainBasePrefab;
    [SerializeField] private GameObject _minorBasePrefab;
    [SerializeField] private GameObject _enemySpawnPrefab;
    [SerializeField] private GameObject _roadSpawn;

    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private int _amountLines;

    private Dictionary<GameObject, List<Edge>> _graph;
    private List<List<GameObject>> _map;
    private List<GameObject> _graphVertexes;

    private GameCore _core;


    private void Awake()
    {
        _core = FindObjectOfType<GameCore>();

        _map = new List<List<GameObject>>();
        _graphVertexes = new List<GameObject>();
        _graph = new Dictionary<GameObject, List<Edge>>();

        for (int i = 0; i < _height; i++)
        {
            _map.Add(new List<GameObject>());
            for (int j = 0; j < _width; j++)
            {
                _map[i].Add(Instantiate(_cellPrefab, new Vector3(j, 0, i), Quaternion.identity));
            }
        }

        SpawnBases();
        PlaceEnemySpawn();
        GameObject temp = _graphVertexes[0];
        _graphVertexes[0] = _graphVertexes[_graphVertexes.Count - 1];
        _graphVertexes[_graphVertexes.Count - 1] = temp;
        //_graph = CreateGraph();
        RemakeGraph();
    }
 
    public void PlaceMapUnit(int x, int z, GameObject unit)
    {
        DeleteMapUnit(x, z);
        _map[z].Insert(x, Instantiate(unit, new Vector3(x, 0, z), unit.transform.rotation));
    }
    private void PlaceMainBase()
    {
        _graphVertexes.Add(Instantiate(_mainBasePrefab, new Vector3(_width - 4, 0, 2), _mainBasePrefab.transform.rotation));
    }
    private void PlaceMinorBase(int minXPos, int minZPos)
    {
        int x = Random.Range(minXPos + 3, (minXPos + _width / 4) - 3);
        int z = Random.Range(minZPos + 3, (minZPos + _height / 2) - 3);
        _graphVertexes.Add(Instantiate(_minorBasePrefab, new Vector3(x, 0, z), _minorBasePrefab.transform.rotation));
    }
    private void PlaceEnemySpawn() 
    {
        _graphVertexes.Add(Instantiate(_enemySpawnPrefab, new Vector3(2, 0, _height - 4), _enemySpawnPrefab.transform.rotation));
    }
    private void DeleteMapUnit(int x, int z)
    {
        Destroy(_map[z][x]);
        _map[z].RemoveAt(x);
    }
   
    private void SpawnBases()
    {
        int stepForIterationX = _width / (_width / 10);
        int stepForIterationY = _height / 2;
        PlaceMainBase();
        for (int i = 0; i < _width - stepForIterationX; i += stepForIterationX)
        {
            for (int j = 0; j < _height; j += stepForIterationY)
            {
                if (i == 0 && j == stepForIterationY) 
                {
                    continue;
                }
                PlaceMinorBase(i, j);
            }
        }
    }
    public List<GameObject> SpawnEnemy(int amount, GameObject _enemyPrefab, Vector3 target)
    {
        return _graphVertexes[0].GetComponent<EnemySpawn>().SpawnEnemy(amount, _enemyPrefab, target);
    }


    public void RemakeGraph()
    {
        _graph = CreateGraph();
    }
    public void DeleteBase()
    {
        for (int i = 0; i < _graphVertexes.Count; i++)
        {
            if(_graphVertexes[i].GetComponent<Base>().GetHealth() <= 0 )
            {
                _graphVertexes[i].GetComponent<Base>().Destroy();
                _graphVertexes.RemoveAt(i);
                --i;
            }
        }
    }
    public Dictionary<GameObject, List<Edge>> CreateGraph()
    {
        Dictionary<GameObject, List<Edge>> temp = new Dictionary<GameObject, List<Edge>>();
        List<Edge> edges = new List<Edge>();
        if (_graphVertexes.Count == 2)
        {
            edges = new List<Edge>();
            AddEdge(0, 1, edges);
            temp.Add(_graphVertexes[0], edges);
        }
        else
        {
            if (_graphVertexes.Count > 4)
            {
                edges = new List<Edge>();
                for (int j = 1; j < 4; j++)
                {
                    AddEdge(0, j, edges);
                }
                temp.Add(_graphVertexes[0], edges);
            }
            else
            {
                edges = new List<Edge>();
                for (int j = 1; j < _graphVertexes.Count - 1; j++)
                {
                    AddEdge(0, j, edges);
                }
                temp.Add(_graphVertexes[0], edges);
            }
            for (int i = 2; i < _graphVertexes.Count - 2; i++)
            {
                edges = new List<Edge>();
                AddEdge(i, i + 1, edges);
                AddEdge(i, i + 2, edges);
                temp.Add(_graphVertexes[i], edges);
            }
            if (_graphVertexes.Count > 2)
            {
                edges = new List<Edge>();
                AddEdge(1, 2, edges);
                temp.Add(_graphVertexes[1], edges);
            }

            if (_graphVertexes[1] != _graphVertexes[_graphVertexes.Count - 2])
            {
                edges = new List<Edge>();
                AddEdge(_graphVertexes.Count - 2, _graphVertexes.Count - 1, edges);
                temp.Add(_graphVertexes[_graphVertexes.Count - 2], edges);
            }
        }
        
        return temp;
    }
    private void AddEdge(int index1, int index2, List<Edge> edges)
    {
        Edge temp = new Edge(_graphVertexes[index1], _graphVertexes[index2], GetDistance(_graphVertexes[index1], _graphVertexes[index2]));
        edges.Add(temp);
        //PrintRoad(_graphVertexes[index1].transform.position, _graphVertexes[index2].transform.position);
    }
    public void PrintRoad()
    {
        foreach (var vertex in _graph)
        {
            foreach (var edge in vertex.Value)
            {
                GameObject temp = Instantiate(_roadSpawn, edge.GetStart().transform.position, Quaternion.identity);

                if (_core.IsInPath(edge.GetStart())){
                    if (_core.IsInPath(edge.GetEnd())){
                        temp.GetComponent<RoadSpawn>().SetTarget(edge.GetEnd().transform.position, true);
                    }
                    else
                    {
                        temp.GetComponent<RoadSpawn>().SetTarget(edge.GetEnd().transform.position);
                    }
                }
                else
                {
                    temp.GetComponent<RoadSpawn>().SetTarget(edge.GetEnd().transform.position);
                }
            }
        }
        
    }


    private float GetDistance(GameObject vertex1, GameObject vertex2)
    {
        return Vector3.Distance(vertex1.transform.position, vertex2.transform.position);
    }
    public Dictionary<GameObject, List<Edge>> GetGraph()
    {
        return _graph;
    }
    public List<GameObject> GetVertexes()
    {
        return _graphVertexes;
    }
}