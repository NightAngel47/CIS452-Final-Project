using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void UpdateData(bool inChaseMode, float movementSpeed, float jumpHeight, Color color, float damageRate, float damageStrength);
}
