using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _menuUI;

    private bool _isPaused = false;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        if (_isPaused)
        {
            _menuUI.SetActive(false);
            Time.timeScale = 1;
            _isPaused = false;
        }
        else
        {
            _menuUI.SetActive(true);
            Time.timeScale = 0;
            _isPaused = true;
        }
    }
}
