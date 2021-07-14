using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinorBase : Base
{
    private List<GameObject> _roads;
    private void Awake()
    {
        _bricks = GetComponentInChildren<BricksColor>();
        _core = FindObjectOfType<GameCore>();
        _roads = new List<GameObject>();
    }

    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            if(enemy.GetTarget() == transform.position)
            {
                enemy.SetTarget(_core.GetEnemyTarget(enemy.GetTargetNumber()));
                TakeDamage(1);
                if(_health == 0)
                {
                    _bricks.SetColor();
                }
            }
        }
    }

    protected override void DeleteBase()
    {
        base.DeleteBase();
    }
    public override void Destroy()
    {
        Destroy(gameObject);
    }
}
