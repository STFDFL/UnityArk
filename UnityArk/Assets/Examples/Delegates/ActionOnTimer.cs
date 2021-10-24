using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOnTimer : MonoBehaviour
{
    private Action _timerCallback;
    private float _timer;


    public void SetTimer(float timer, Action timerCallback)
    {
        _timer = timer;
        _timerCallback = timerCallback;
    }

    
    private void Update()
    {
        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;

            if (IsTimerComplete())
            {
                _timerCallback();
            }
        }
    }


    private bool IsTimerComplete()
    {
        return _timer <= 0;
    }
}
