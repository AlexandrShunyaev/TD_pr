using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float _fillSpeed;

    private ParticleSystem _particleSys;
    private Slider _slider;
    //private float _targetProgress = 0;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _particleSys = FindObjectOfType<ParticleSystem>();
    }

    private void Update()
    {
        /*if (_slider.value < _targetProgress)
        {
            _slider.value = _targetProgress;
            if (!_particleSys.isPlaying)
            {
                _particleSys.Play();
            }
        }
        else
        {
            _particleSys.Stop();
        } */
    }

    public void IncreaseProgress(float newProgress)
    {
        // _targetProgress = _slider.value + newProgress;
        if(newProgress == 0f)
        {
            _slider.value = 0f;
        }
        _slider.value += newProgress;
    }
}
