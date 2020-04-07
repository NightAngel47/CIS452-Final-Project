using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmBatBehaviorData : MonoBehaviour, ISubject
{
    private List<IObserver> observerList = new List<IObserver>();

    private bool chasingPlayer;
    public float batMoveSpeed = 1f;
    public float batJump = 1f;

    private Color batColor;
    public Color normalBatColor;
    public Color lowHealthBatColor;

    public float batRateOfDamage = 1f;
    public float batDamageStrength = 1f;

    // Start is called before the first frame update
    void Start()
    {
        chasingPlayer = false;
        batColor = normalBatColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(!chasingPlayer)
            {
                chasingPlayer = true;
                NotifyObservers();
            }
            else if(chasingPlayer)
            {
                chasingPlayer = false;
                NotifyObservers();
            }
        }
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observerList)
        {
            observer.UpdateData(chasingPlayer, batMoveSpeed, batJump, batColor, batRateOfDamage, batDamageStrength);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observerList.Add(observer);
        observer.UpdateData(chasingPlayer, batMoveSpeed, batJump, batColor, batRateOfDamage, batDamageStrength);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observerList.Contains(observer))
        {
            observerList.Remove(observer);
        }
    }
}
