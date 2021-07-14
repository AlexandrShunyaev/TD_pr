using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _health; 
    [SerializeField] protected float _speed;
    [SerializeField] protected float _currentSpeed = 0f;
    [SerializeField] protected int _goldForDeath;

    protected int _targetNumber = 1;
    protected Vector3 _target;
    protected Transform _transform;
    protected GameCore _core;

    public abstract void TakeDamage(float damage);
    public abstract int GetTargetNumber();
    public abstract float GetSpeed();
    public abstract Vector3 GetTarget();
    public abstract void SetTarget(Vector3 target);
    public abstract void MakeSlower(float value);
    public abstract void Destroy();
    public abstract void SetSpeed();
}
