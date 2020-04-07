using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmBehaviorData : MonoBehaviour, ISubject
{
    private List<IObserver> observerList = new List<IObserver>();

    private bool chasingPlayer;
    public float moveSpeed = 1f;
    public float jumpHeight = 1f;

    private Color color;
    public Color normalColor;
    public Color lowHealthColor;

    public float rateOfDamage = 1f;
    public float damageStrength = 1f;

    // Start is called before the first frame update
    void Start()
    {
        chasingPlayer = false;
        color = normalColor;
        NotifyObservers();
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
            observer.UpdateData(chasingPlayer, moveSpeed, jumpHeight, color, rateOfDamage, damageStrength);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observerList.Add(observer);
        observer.UpdateData(chasingPlayer, moveSpeed, jumpHeight, color, rateOfDamage, damageStrength);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observerList.Contains(observer))
        {
            observerList.Remove(observer);
        }
    }
}
