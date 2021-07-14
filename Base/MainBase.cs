using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBase : Base
{
    private void Awake()
    {
        _core = FindObjectOfType<GameCore>();
    }
    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    private void Update()
    {
        if(_health <= 0)
        {
            _core.StopGame();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            TakeDamage(1);
        }
    }
}
