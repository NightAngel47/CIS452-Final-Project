﻿/*
* William Nomikos
* SwarmBehaviorData.cs
* Final Project
* Subject that handles notifying its concrete observers. If its observers
* should be chasing the players, the observers will be notified.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmBehaviorData : MonoBehaviour, ISubject
{
    private List<IObserver> observerList = new List<IObserver>();

    public bool chasingPlayer;
    public float moveSpeed = 1f;
    public float jumpHeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        chasingPlayer = false;
        NotifyObservers();
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observerList)
        {
            observer.UpdateData(chasingPlayer, moveSpeed);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observerList.Add(observer);
        observer.UpdateData(chasingPlayer, moveSpeed);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observerList.Contains(observer))
        {
            observerList.Remove(observer);
        }
    }
}
