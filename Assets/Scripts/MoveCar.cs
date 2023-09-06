using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// при подключении скрипта к объекту (машинке) автоматически подключается скрипт Rigitbody
[RequireComponent(typeof(Rigidbody))]
public class MoveCar : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 9f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // плавное движение прямо
        rb.MovePosition(transform.position - transform.forward * speed * Time.fixedDeltaTime);
    }
}
