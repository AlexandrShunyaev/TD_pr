using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    private List<List<GameObject>> _map;
    private void Awake()
    {
        _map = new List<List<GameObject>>();
        for (int i = 0; i < _height; i++)
        {
            _map.Add(new List<GameObject>());
            for (int j = 0; j < _width; j++)
            {
                _map[i].Add(Instantiate(_cellPrefab, new Vector3(j, 0, i), Quaternion.identity));
            }
        }
    }
}
