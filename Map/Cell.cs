using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _x;
    [SerializeField] private int _z;
    [SerializeField] private GameCore _core;

    private void Awake()
    {
        _x = (int)GetComponent<Transform>().position.x;
        _z = (int)GetComponent<Transform>().position.z;

        _core = FindObjectOfType<GameCore>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _core.EnableBuyUI(_x, _z);
    }
}
