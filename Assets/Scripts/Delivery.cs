using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Delivery : MonoBehaviour
{

    [SerializeField] float destroyDelay= 0.5f; /*Package destroy delay*/
    [SerializeField] Color32 packageColor= new Color32 (250,250,250,255); /*Car's color when dont have any cargo*/

    bool packageGet = false; /*Shows if package get or not*/

    string packageRGB = null; /*Shows which color package have been picked up*/
    SpriteRenderer spriteRenderer;
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Oh No!"); /*When crush anything displays this message*/
    }

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>(); /*Loads car's sprite to spriteRenderer*/
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "GreenPackage" && packageGet == false)
        {
            Debug.Log("Green Package Packed!"); /*Displays package get message*/
            packageGet = true; /*When package have been get displays this*/
            Destroy(other.gameObject, destroyDelay); /*Destroy package when player gets it*/
            spriteRenderer.color = new Color32(0, 255, 0, 255); /*Changes car's color to package color*/
            packageRGB = "Green"; /*Saves package color for give it true customer*/
            GameManager.Instance.PackagePickedUpForDelivery("Green");

        }
        else if (other.tag == "RedPackage" && packageGet == false)
        {

            Debug.Log("Red Package Packed!");
            packageGet = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = new Color32(255, 0, 0, 255);
            packageRGB = "Red";
            GameManager.Instance.PackagePickedUpForDelivery("Red");
        }
        else if (other.tag == "BluePackage" && packageGet == false)
        {

            Debug.Log("Blue Package Packed!");
            packageGet = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = new Color32(0, 0, 255, 255);
            packageRGB = "Blue";
            GameManager.Instance.PackagePickedUpForDelivery("Blue");
        }
        else if (other.tag == "CustomerR" && packageGet && packageRGB == "Red")
        { /*If customer is right giver package and returns car to first color*/

            Debug.Log("Package Delivered!");
            packageGet = false;
            spriteRenderer.color = packageColor;
            GameManager.Instance.IncreaseDeliveredPackageCount();
        }
        else if (other.tag == "CustomerG" && packageGet && packageRGB == "Green")
        {

            Debug.Log("Package Delivered!");
            packageGet = false;
            spriteRenderer.color = packageColor;
            GameManager.Instance.IncreaseDeliveredPackageCount();
        }
        else if (other.tag == "CustomerB" && packageGet && packageRGB == "Blue")
        {

            Debug.Log("Package Delivered!");
            packageGet = false;
            spriteRenderer.color = packageColor;
            GameManager.Instance.IncreaseDeliveredPackageCount();
        }
    }
}
