using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsUI : MonoBehaviour
{
    [SerializeField] private int _startValue;

    private Text _text;
    private int _currentValue = 0;

    private void Awake()
    {
        _text = gameObject.GetComponentInChildren<Text>();
        _currentValue = _startValue;
    }
    private void Start()
    {
        _text.text = "Rounds: " + _startValue.ToString();
    }

    public void SetRound(int value)
    {
        _currentValue = value;
        _text.text = "Rounds: " + _currentValue.ToString();
    }
}
