using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestingEvents : MonoBehaviour
{

    // Event Args
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
    public class OnSpacePressedEventArgs : EventArgs
    {
        public int spaceCount;
    }
    private int _spaceCount;

    // Event Delegates
    public event TestEventDelegate OnFloatEvent;
    public delegate void TestEventDelegate(float f);


    // Event Action 
    public Action<bool, int> OnActionEvent;

    // Unity Event
    public UnityEvent OnUnityEvent;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _spaceCount++;
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs {spaceCount = _spaceCount});

            OnFloatEvent?.Invoke(1.111f);

            OnActionEvent?.Invoke(true, 123);

            OnUnityEvent?.Invoke();
        }
    }
}
