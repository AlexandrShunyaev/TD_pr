using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] protected float _range;
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _upgradeScale;

    [SerializeField] protected int _amountAttackUnits;

    [SerializeField] protected AttackUnit _prefab;

    protected float _attackTimer = 0f;
    protected Enemy _target;
    protected Transform _transform;
    protected List<AttackUnit> _attackUnits;

    protected abstract void Attack();
    protected abstract void Upgrade();
}
