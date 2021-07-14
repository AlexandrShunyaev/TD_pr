using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    [SerializeField] private int _startValue;

    private Text _text;
    private int _currentValue = 0;

    private void Awake()
    {
        _text = gameObject.GetComponent<Text>();
        _currentValue = _startValue;
    }
    private void Start()
    {
        _text.text = _startValue.ToString();
    }

    public void AddMoney(int value)
    {
        _currentValue += value;
        _text.text = _currentValue.ToString();
    }
    public void SpendMoney(int value)
    {
        _currentValue -= value;
        _text.text = _currentValue.ToString();
    }
    public bool IsEnoughMoney(int value)
    {
        return value <= _currentValue;
    }
}
