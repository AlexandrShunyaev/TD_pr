using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _collider = GetComponent<SphereCollider>();
        _attackUnits = new List<AttackUnit>();

        _collider.radius = _range;

        for (int i = 0; i < _amountAttackUnits; i++)
        {
            _attackUnits.Add(Instantiate(_prefab,
                                         new Vector3(_transform.position.x, _transform.position.y + 3, _transform.position.z),
                                         Quaternion.identity));

            _attackUnits[i].gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (_target != null)
        {
            if (_attackTimer <= 0f)
            {
                Attack();
            }
            else
            {
                _attackTimer -= Time.deltaTime;
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (_target == null && other.gameObject.GetComponent<Enemy>())
        {
            _target = other.gameObject.GetComponent<Enemy>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_target == other.gameObject.GetComponent<Enemy>())
        {
            _target = null;
        }
    }

    protected override void Attack()
    {
        for (int i = 0; i < _amountAttackUnits; i++)
        {
            if (!(_attackUnits[i].gameObject.activeInHierarchy))
            {
                _attackUnits[i].gameObject.SetActive(true);
                _attackUnits[i].SetTarget(_target);
                _attackTimer = _attackSpeed;
                break;
            }
            else if (i == _amountAttackUnits - 1)
            {
                _attackUnits.Add(Instantiate(_prefab,
                                             new Vector3(_transform.position.x, _transform.position.y + 3, _transform.position.z),
                                             Quaternion.identity));
                ++_amountAttackUnits;
                _attackUnits[_amountAttackUnits - 1].gameObject.SetActive(false);
            }
        }

    }
    protected override void Upgrade()
    {
        _range *= _upgradeScale;
        for (int i = 0; i < _amountAttackUnits; i++)
        {
            _attackUnits[i].Upgrade(_upgradeScale);
        }
    }
}
