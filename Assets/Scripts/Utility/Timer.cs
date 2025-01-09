using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _delay;

    public UnityAction OnTimeAction;
    
    private Sequence _sequence;

    private bool _loop = false;

    public void StartTimer()
    {
        _loop = true;

        _sequence = null;
        _sequence = DOTween.Sequence();
        _sequence.SetDelay(_delay);
        _sequence.AppendCallback(Callback);
        _sequence.Play();
    }

    public void StopTimer()
    {
        _loop = false;
    }

    private void Callback()
    {
        OnTimeAction?.Invoke();

        if (!_loop)
            return;

        StartTimer();
    }
}
