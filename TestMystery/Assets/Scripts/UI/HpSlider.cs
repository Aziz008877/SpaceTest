using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HpSlider : MonoBehaviour
{
    private Slider _hpSlider;
    private float _hpValue = 3;
    [SerializeField] private Ease _easeType;
    [SerializeField] private float _duration;
    [SerializeField] private UnityEvent _onGameOver;
    private void Awake()
    {
        _hpSlider = GetComponent<Slider>();
        _hpValue = 3;
        SetSliderEqualHp();
    }

    public void DecreaseHpValue(float damageAmount)
    {
        if (_hpSlider.value - damageAmount > 0)
        {
            _hpValue -= damageAmount;
            SetSliderEqualHp();
        }
        else
        {
            _hpValue -= damageAmount;
            SetSliderEqualHp();
            _onGameOver?.Invoke();
        }
    }
    
    private void SetSliderEqualHp()
    {
        _hpSlider
            .DOValue(_hpValue, _duration)
            .SetEase(_easeType);
    }
}
