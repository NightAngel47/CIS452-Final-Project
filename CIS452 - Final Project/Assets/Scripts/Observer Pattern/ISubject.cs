/*
* William Nomikos
* ISubject.cs
* Final Project
* Subject interface allows observers to be registered, removed, and notified.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
