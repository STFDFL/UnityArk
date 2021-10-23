using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEventSubscriber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestingEvents testingEvents = GetComponent<TestingEvents>();

        testingEvents.OnSpacePressed += TestingEvents_OnSpacePressed;
        testingEvents.OnFloatEvent += TestingEvents_OnFloatEvent;
        testingEvents.OnActionEvent += TestingEvents_OnActionEvent;
    }


    private void TestingEvents_OnActionEvent(bool arg1, int arg2)
    {
        Debug.Log(arg1 + " " + arg2);

    }


    private void TestingEvents_OnFloatEvent(float f)
    {
        
        Debug.Log("Space Float!!! " + f);
    }


    private void TestingEvents_OnSpacePressed(object sender, TestingEvents.OnSpacePressedEventArgs e)
    {
        Debug.Log("Space!!! " + e.spaceCount);
    }


    public void TestingUnityEvent()
    {
        Debug.Log("Space Unity Event!!! ");
    }
}
