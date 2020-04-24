/*
* William Nomikos
* IObserver.cs
* Final Project
* Observer interface that updates data to observers.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void UpdateData(bool inChaseMode, float movementSpeed);
}
