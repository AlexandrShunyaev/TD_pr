using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base : MonoBehaviour
{
    [SerializeField] protected int _health;
    protected BricksColor _bricks;
    protected int _number;

    protected GameCore _core;

    protected virtual void TakeDamage(int damage)
    {
        _health -= damage;
    }

    protected virtual void DeleteBase()
    {
        _core.DeleteBase();
    }

    public virtual void Destroy()
    {
        
    }
    public virtual int GetHealth()
    {
        return _health;
    }
}
