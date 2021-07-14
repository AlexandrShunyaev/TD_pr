using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra
{
    struct Priority
    {
        public GameObject Vertex;
        public float PriorityValue;
    }
    private int Comparator(Priority a, Priority b)
    {
        if (a.PriorityValue == -1)
        {
            return 1;
        }
        if (b.PriorityValue == -1)
        {
            return -1;
        }
        if (a.PriorityValue > b.PriorityValue)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
    private Dictionary<GameObject, List<Edge>> _graph;
    private List<Priority> _priorityList;
    private List<GameObject> _vertexes;
    private Dictionary<GameObject, GameObject> _theWay;
    private List<GameObject> _answer;
    private GameObject _start;
    private GameObject _end;

    public Dijkstra(Dictionary<GameObject, List<Edge>> graph, List<GameObject> vertexes)
    {
        _theWay = new Dictionary<GameObject, GameObject>();
        _graph = new Dictionary<GameObject, List<Edge>>();
        _vertexes = new List<GameObject>();
        _vertexes = vertexes;
        _graph = graph;
        _start = vertexes[0];
        _end = vertexes[vertexes.Count - 1];
        _answer = new List<GameObject>();
        _priorityList = new List<Priority>();
        _priorityList.Add(new Priority { Vertex = vertexes[0], PriorityValue = 0 });
        for (int i = 1; i < _vertexes.Count; i++)
        {
            _priorityList.Add(new Priority { Vertex = _vertexes[i], PriorityValue = -1 });
        }
    }

    public bool Algorithm()
    {
        while (_priorityList.Count != 0)
        {
            _priorityList.Sort(Comparator);
            Debug.Log($"Another Iteration with priority - {_priorityList[0].PriorityValue}\n");
            foreach (Priority vertex in _priorityList)
            {
                Debug.Log($"Priority - {vertex.PriorityValue}; ");
            }
            if (_priorityList[0].Vertex == _end)
            {
                GameObject key = _end;
                while (key != _start)
                {
                    _answer.Add(key);
                    key = _theWay[key];
                };
                _answer.Add(key);
                _answer.Reverse();
                return true;
            }
            else
            {
                List<Edge> edges = _graph[_priorityList[0].Vertex];
                foreach (Edge edge in edges)
                {
                    for (int i = 1; i < _priorityList.Count; i++)
                    {
                        if (edge.GetEnd() == _priorityList[i].Vertex)
                        {
                            if (((edge.GetDistance() + _priorityList[0].PriorityValue) < _priorityList[i].PriorityValue) || (_priorityList[i].PriorityValue == -1))
                            {
                                _priorityList[i] = new Priority { Vertex = edge.GetEnd(), PriorityValue = edge.GetDistance() + _priorityList[0].PriorityValue};
                                _theWay[_priorityList[i].Vertex] = _priorityList[0].Vertex;
                            }
                        }
                    }
                }
                _priorityList.RemoveAt(0);
            }
        }
        Debug.Log($"No way");
        return false;
    }

    public List<GameObject> GetAnswer()
    {
        return _answer;
    }
}