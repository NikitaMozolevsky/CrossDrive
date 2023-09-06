using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarLights))]
[RequireComponent(typeof(MoveCar))]
public class WestTurnLeft : MonoBehaviour
{

    private Rigidbody rb;
    private float eulerAngeleVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<CarLights>().showObject = 1;
    }

    private void FixedUpdate()
    {
        LeftTurn();
    }

    private void LeftTurn()
    {
        float carRotation = Mathf.Floor(transform.eulerAngles.y); // округление т.к. возвращается длинное число
        if (transform.localPosition.x > 2f && carRotation != 180)
        { // скорость поворота, "-" - т.к. поврот на лево
            if (carRotation <= 180f && carRotation >= 176f)
            { // на случай если скорость большая, останавливается процесс поворота
                transform.localRotation = Quaternion.Euler(new Vector3(0, 180f, 0));
                return;
            }
            eulerAngeleVelocity = GetComponent<MoveCar>().speed * -8.57f;
            Quaternion deltaRotation = Quaternion.Euler(
                new Vector3(0, eulerAngeleVelocity, 0) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation); // 
        }
    }
}
