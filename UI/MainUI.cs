using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    private ProgressBar _progressBar;
    private BuyUI _buyUI;
    private Coins _coins;
    private RoundsUI _round;

    private void Awake()
    {
        _progressBar = FindObjectOfType<ProgressBar>();
        _buyUI = FindObjectOfType<BuyUI>();
        _coins = FindObjectOfType<Coins>();
        _round = FindObjectOfType<RoundsUI>();
        //_buyUI.gameObject.SetActive(false);
        DisableBuyUI();
        DisableRoundUI();
    }

    public void IncreaseProgress(float newProgress)
    {
        _progressBar.IncreaseProgress(newProgress);
    }

    public void EnableBuyUI(int x, int z)
    {
        _buyUI.gameObject.SetActive(true);
        _buyUI.SetPosition(x, z);
    }
    public void DisableBuyUI()
    {
        _buyUI.gameObject.SetActive(false);
    }
    public void EnableRoundUI()
    {
        _round.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void DisableRoundUI()
    {
        _round.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void AddMoney(int value)
    {
        _coins.AddMoney(value);
    }
    public void SpendMoney(int value)
    {
        _coins.SpendMoney(value);
    }
    public bool IsEnoughMoney(int value)
    {
        return _coins.IsEnoughMoney(value);
    }

    public void SetRound(int value)
    {
        _round.SetRound(value);
    }
}
