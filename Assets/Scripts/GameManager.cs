using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int deliveredPackages = 0;
    public int totalPackages = 3;
    public event Action GameIsOver;
    public event Action<string> PackagePickedUp;
    public event Action PackageDelivered;

    void Awake()
    {
        Instance = this;
    }

    public void IncreaseDeliveredPackageCount()
    {
        if (deliveredPackages < totalPackages)
        {
            deliveredPackages++;
            PackageDelivered.Invoke();
        }

        if (deliveredPackages == totalPackages)
        {
            GameIsOver.Invoke();
        }
    }

    public void PackagePickedUpForDelivery(string color)
    {
        PackagePickedUp.Invoke(color);
    }

    public int GetDeliveredPackageCount()
    {
        return deliveredPackages;
    }
}
