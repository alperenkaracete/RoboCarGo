using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PackageInformation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waitingDeliveries;
    [SerializeField] private TextMeshProUGUI _totalDeliviredPackage;
    [SerializeField] private TextMeshProUGUI _packageColor;

    void Start()
    {
        GameManager.Instance.PackagePickedUp += PackagePickedUp;
        GameManager.Instance.PackageDelivered += PackageDelivered;
    }

    private void PackageDelivered()
    {
        string deliveredText = "Total Delivered Packages: ";
        string waitingText = "Total Waiting Customers: ";
        deliveredText += GameManager.Instance.GetDeliveredPackageCount();
        waitingText += GameManager.Instance.totalPackages - GameManager.Instance.GetDeliveredPackageCount();
        _totalDeliviredPackage.text = deliveredText;
        _waitingDeliveries.text = waitingText;
        _packageColor.text = "Carrying Package Color: None";
    }

    private void PackagePickedUp(string color)
    {
        string packageText = "Carrying Package Color: ";
        packageText += color;
        _packageColor.text = packageText;
    }
}
