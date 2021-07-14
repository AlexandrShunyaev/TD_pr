using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttackUnit : AttackUnit
{
    [SerializeField] private float _deceleration;
    private void Awake()
    {
        _transform = GetComponent<Transform>();

        _startPosition = _transform.position;
        _speed = _defualtSpeed;
    }
    private void FixedUpdate()
    {
        if (_target != null)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _target.transform.position, _speed * Time.deltaTime);
            _speed += _speedBoost;
        }
        else
        {
            if (this.gameObject.activeInHierarchy)
            {
                UnitDestroy();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy temp = other.gameObject.GetComponent<Enemy>();
        if (temp != null)
        {
            temp.TakeDamage(_damage);
            temp.MakeSlower(_deceleration);
            if(temp == _target)
            {
                UnitDestroy();
            }
            
        }
    }

    public override void SetTarget(Enemy target)
    {
        _target = target;
    }
    public override void Upgrade(float upgradeScale)
    {
        _damage *= upgradeScale;
        _speed *= upgradeScale;
    }
    protected override void UnitDestroy()
    {
        _target = null;
        _speed = _defualtSpeed;
        _transform.position = _startPosition;
        gameObject.SetActive(false);
    }
}
