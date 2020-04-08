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
