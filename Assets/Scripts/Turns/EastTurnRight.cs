using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarLights))]
[RequireComponent(typeof(MoveCar))]
public class EastTurnRight : MonoBehaviour
{
    private Rigidbody rb;
    private float eulerAngeleVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<CarLights>().showObject = 0;
    }

    private void FixedUpdate()
    {
        LeftTurn();
    }

    private void LeftTurn()
    {
        float carRotation = Mathf.Floor(transform.eulerAngles.y); // округление т.к. возвращается длинное число
        if (transform.localPosition.x < 16f && carRotation != 180f)
        { // скорость поворота, "-" - т.к. поврот на лево
            if (carRotation >= 180f && carRotation <= 184f)
            { // на случай если скорость большая, останавливается процесс поворота
                transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                return;
            } // поворот в обратную сторону поэтом +8.57f
            eulerAngeleVelocity = GetComponent<MoveCar>().speed * 8.57f;
            Quaternion deltaRotation = Quaternion.Euler(
                new Vector3(0, eulerAngeleVelocity, 0) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation); // 
        }
    }
}