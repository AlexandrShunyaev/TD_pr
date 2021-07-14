using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _roadPrefab;
    [SerializeField] private GameObject _pathRoadPrefab;

    private Vector3 _target;
    private Transform _transform;

    private float _timer = 0;
    private float _time = 0.2f;

    private bool _isPath = false;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if(_target != null)
        {
            if(_transform.position != _target)
            {
                _transform.position = Vector3.MoveTowards(_transform.position, _target, 0.2f);
                if(_timer >= _time)
                {
                    if (_isPath)
                    {
                        Instantiate(_pathRoadPrefab, _transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(_roadPrefab, _transform.position, Quaternion.identity);
                    }
                    _timer = 0;
                }
                else
                {
                    _timer += Time.deltaTime;
                }
                
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetTarget(Vector3 target, bool isPath = false)
    {
        _target = target;
        _isPath = isPath;
    }
}
