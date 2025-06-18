using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]float steerSpeed = 0.1f; /*Rotation speed*/
    [SerializeField]float moveSpeed = 0.01f; /*Movement speed*/

    [SerializeField] float speedUp = 20f; /*Speed up buff*/
    [SerializeField] float slowDown= 20f; /*Slow down nerf*/
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.GameIsOver += GameIsOver;
    }

    private void GameIsOver()
    {
        isGameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; /*Rotation speed with frame*/
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; /*Movement speed with frame*/

            transform.Rotate(0, 0, -steerAmount); /*Rotate car*/
            transform.Translate(0, moveAmount, 0); /*Move car*/
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="SpeedUp"){ /*If player gets speed up buff*/
            
            moveSpeed += speedUp;
        }

        else if (other.tag=="SlowDown"){ /*Else if gets slow down buff*/
            if (moveSpeed>20) /*Prevent speed to decrease minus*/
                moveSpeed -= slowDown;
        }
    }
}
