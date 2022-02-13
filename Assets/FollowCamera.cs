using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject followCar;
    void LateUpdate()
    {
        transform.position=followCar.transform.position + new Vector3 (0,0,-10); /*Allows camera to follow car.*/
    }
}
