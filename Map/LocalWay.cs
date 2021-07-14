using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalWay
{
    private List<GameObject> _localWayList;
    private float _distance = 0;

    public LocalWay(LocalWay another, Edge edge)
    {
        _localWayList = another._localWayList;
        _localWayList.Add(edge.GetEnd());
        _distance = another.GetDistance() + edge.GetDistance();
    }

    public LocalWay(Edge edge)
    {
        _localWayList = new List<GameObject>();
        _localWayList.Add(edge.GetStart());
    }

    public List<GameObject> GetLocalWayList()
    {
        return _localWayList;
    }

    public float GetDistance() {
        return _distance;
    }
}