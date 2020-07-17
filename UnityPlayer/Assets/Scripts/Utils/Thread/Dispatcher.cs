using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System;

[AddComponentMenu("Utils/Dispatcher")]
public class Dispatcher : MonoBehaviour
{

    private static Dispatcher instance;
    private static bool instanceExists;

    private static Thread mainThread;
    private static object lockObject = new object();
    private static readonly Queue<Action> actions = new Queue<Action>();

    public static bool IsMainThread
    {
        get => Thread.CurrentThread == mainThread;
    }

    public static void InvokeAsync(Action action)
    {
        if (instanceExists == false)
        {
            Debug.LogError("No Dispatcher exists in the scene...");
            return;
        }

        if (IsMainThread == true)
        {
            action();
        }
        else
        {
            lock (lockObject)
            {
                actions.Enqueue(action);
            }
        }
    }

    public static void Invoke(Action action)
    {
        if (instanceExists == false)
        {
            Debug.LogError("No Dispatcher exists in the scene...");
            return;
        }

        bool hasRun = false;

        InvokeAsync(() =>
        {
            action();
            hasRun = true;
        });

        while (hasRun == false)
        {
            Thread.Sleep(10);
        }
    }

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(this);
        }
        else
        {
            instance = this;
            instanceExists = true;
            mainThread = Thread.CurrentThread;
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
            instanceExists = false;
        }
    }

    private void Update()
    {
        lock (lockObject)
        {
            while (actions.Count > 0)
            {
                actions.Dequeue()();
            }
        }
    }
}
