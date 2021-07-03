using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackUnit : MonoBehaviour
{
    [SerializeField] protected float _defualtSpeed;
    [SerializeField] protected float _speedBoost;
    [SerializeField] protected float _damage;

    protected float _speed;

    protected Vector3 _startPosition;
    protected Transform _transform;
    protected Enemy _target;
    
    public abstract void SetTarget(Enemy target);
    public abstract void Upgrade(float upgradeScale);
    protected abstract void Destory();

}
