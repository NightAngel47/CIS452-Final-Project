using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineCommand : MonoBehaviour, Command
{
    public void Execute()
    {
        CombineReceiver.Combine();
    }

    public void Undo()
    {
        CombineReceiver.Split();
    }
}
