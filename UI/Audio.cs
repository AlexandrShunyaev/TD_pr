using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField] private Sprite[] _switchSprites;

    private Image _switchImage;
    private int _audioState;
    private void Awake()
    {
        if (AudioListener.volume == 0.0f)
        {
            _audioState = 0;
        } else
        {
            _audioState = 1;
        }
    }

    void Start()
    {
        _switchImage = gameObject.GetComponent<Button>().image;
        _switchImage.sprite = _switchSprites[_audioState];
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeAudioState);
    }

    private void ChangeAudioState()
    {
        _audioState = 1 - _audioState;
        AudioListener.volume = _audioState;
        _switchImage.sprite = _switchSprites[_audioState];
    }
}
