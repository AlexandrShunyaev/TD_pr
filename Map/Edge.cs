using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    private GameObject _start;
    private GameObject _end;
    private float _distance;

    public Edge(GameObject start, GameObject end, float distance)
    {
        _start = start;
        _end = end;
        _distance = distance;
    }

    public GameObject GetStart() {
        return _start;
    }

    public GameObject GetEnd()
    {
        return _end;
    }

    public float GetDistance() {
        return _distance;
    }
}
