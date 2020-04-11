/*
* Conner Wolf
* EquipReceiver.cs
* Final Project
* Pushes and pops tomes to and from stack upon tomes being equipped or dequipped. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EquipReceiver
{
    public static void Equip()
    {
        if (Player_Equip_Invoker.currentTome != null)
        {
            Player_Equip_Invoker.tomeStack.Push(Player_Equip_Invoker.currentTome);
            Player_Equip_Invoker.currentTome = null;
        }
    }

    public static void Dequip()
    {
        if (Player_Equip_Invoker.tomeStack.Peek() != null)
        {
            Player_Equip_Invoker.currentTome = Player_Equip_Invoker.tomeStack.Pop();
        }
    }
}
