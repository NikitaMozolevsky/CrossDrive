using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveCar))]
public class CollisionCars : MonoBehaviour
{

    public GameObject explode; 
    public static bool lose = false;
    private bool onceStop; // для срабатывания аварии только один раз

    // сработает при сталкивании двух boxCollider без триггера
    private void OnCollisionEnter(Collision otherObject)
    {
        if (otherObject.gameObject.tag == "Player" && !onceStop)
        {
            lose = true;
            onceStop = true;
            
            // остановка обоих машинок
            gameObject.GetComponent<MoveCar>().speed = 0f;
            otherObject.gameObject.GetComponent<MoveCar>().speed = 0f;
            
            // добавление удара в нароавлении Vector3 прямо с силой -1000
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * -1000);
            
            // Взрыв для машинки ктороая находится дальше
            if (gameObject.transform.position.x < otherObject.transform.position.x)
            {
                Vector3 pos = Vector3.Lerp // расположить взрыв в середине между двуля маозициями
                    (gameObject.transform.position, otherObject.transform.position, 0.5f);
                Instantiate(explode, new Vector3(pos.x, 2.7f, pos.z), Quaternion.identity);
            }

        }
    }
}
