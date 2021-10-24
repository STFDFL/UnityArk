using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingDelegates : MonoBehaviour
{
    public delegate void TestDelegate();
    public delegate bool TestBoolDelegate(int i);

    private TestDelegate testDelegateFunction;
    private TestBoolDelegate testBoolDelegateFunction;

    private Action testAction;
    private Action<int, float> testIntFloatAction;

    private Func<bool> testFunc;
    private Func<int, bool> testIntBoolFunc;

    void Start()
    {
        testDelegateFunction += () => { Debug.Log("Lambda"); };
        testDelegateFunction += () => { Debug.Log("Second Lambda"); };
        testDelegateFunction();

        testIntFloatAction = (int i, float f) => { Debug.Log("Test int float action"); };

        testFunc = () => false;
        testIntBoolFunc = (int i) => { return i < 5; };


    }


}
