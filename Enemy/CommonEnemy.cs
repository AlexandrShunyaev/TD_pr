using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemy : Enemy
{
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _core = FindObjectOfType<GameCore>();
        _target = _transform.position;
    }
    private void FixedUpdate()
    {
        if(_health <= 0)
        {
            Destroy();
        }
        if (_target != _transform.position)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _target, _currentSpeed * Time.deltaTime);
        }
    }

    public override void TakeDamage(float damage)
    {
        _health -= damage;
    }
    public override void Destroy()
    {
        _core.AddMoney(_goldForDeath);
        _core.DeleteEnemy(gameObject);
        Destroy(gameObject);
    }
    public override int GetTargetNumber()
    {
        return ++_targetNumber;
    }
    public override Vector3 GetTarget()
    {
        return _target;
    }
    public override void SetTarget(Vector3 target)
    {
        _target = target;
    }
    public override void MakeSlower(float value)
    {
        _speed -= value;
    }
    public override void SetSpeed()
    {
        _currentSpeed = _speed;
    }
    public override float GetSpeed()
    {
        return _currentSpeed;
    }
}
