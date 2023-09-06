using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarLights))]
[RequireComponent(typeof(MoveCar))]
public class EastTurnLeft : MonoBehaviour
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
        if (transform.localPosition.x < 10f && carRotation != 0f)
        { // скорость поворота, "-" - т.к. поврот на лево
            if (carRotation <= 0f && carRotation >= 356f)
            { // на случай если скорость большая, останавливается процесс поворота
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                return;
            } // поворот в обратную сторону поэтом +8.57f
            eulerAngeleVelocity = GetComponent<MoveCar>().speed * -8.57f;
            Quaternion deltaRotation = Quaternion.Euler(
                new Vector3(0, eulerAngeleVelocity, 0) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation); // 
        }
    }
}