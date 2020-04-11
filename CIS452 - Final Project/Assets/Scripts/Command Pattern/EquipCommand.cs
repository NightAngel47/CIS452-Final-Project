/*
* Conner Wolf
* EquipCommand.cs
* Final Project
* Equips and unequips tomes to the receiver. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipCommand : MonoBehaviour, Command
{
    public void Execute()
    {
        EquipReceiver.Equip();
    }

    public void Undo()
    {
        EquipReceiver.Dequip();
    }
}
