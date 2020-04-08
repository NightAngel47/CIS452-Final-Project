using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CombineReceiver
{
    public static void Combine()
    {
        //Claim the current tomes from the player and push the offhand to the history stack.
        Tome tomeA = Player_Combine_Invoker.currentTome;
        Tome tomeB = Player_Combine_Invoker.offhandTome;
        Player_Combine_Invoker.tomeStack.Push(tomeB);
        Player_Combine_Invoker.offhandTome = null;

        tomeA.damage += tomeB.damage;
        tomeA.rateOfFire /= tomeB.rateOfFire;
        
    }

    public static void Split()
    {
        Tome tomeA = Player_Combine_Invoker.currentTome;
        Tome tomeB = Player_Combine_Invoker.tomeStack.Pop();

        tomeA.damage -= tomeB.damage;
        tomeA.rateOfFire *= tomeB.rateOfFire;

        Player_Combine_Invoker.offhandTome = tomeB;
    }
}
