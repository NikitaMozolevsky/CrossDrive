using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(MoveCar))]
public class FirstStep : MonoBehaviour
{

    public GameObject secondCar;
    public TextMeshProUGUI study;
    private bool firstStep;

    private void Start()
    {
        GetComponent<MoveCar>().speed = 0f;
        Invoke("MoveCar", 1f); // MoveCar сработает через 1 секунду
    }

    private void Update()
    {
        if (transform.position.x < 22f && !firstStep)
        {
            firstStep = true;
            GetComponent<MoveCar>().speed = 2f;
            study.text = "Tap the car to accelerate it";
        }
    }

    void MoveCar() // дает машинке скорость
    {
        GetComponent<MoveCar>().speed = 13f;
    }

    private void OnMouseDown()
    {
        if (firstStep)
        {
            GetComponent<MoveCar>().speed = 30f;
            study.text = "";
        }
    }

    private void OnDisable()
    {
        secondCar.SetActive(true);
    }
}
