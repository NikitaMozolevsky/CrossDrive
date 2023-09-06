using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour
{

    public int showObject; // 0 или 1, индекс фары
    private void Start()
    {
        StartCoroutine(Light());
    }

    IEnumerator Light()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject light = gameObject.transform.GetChild(showObject).gameObject;

        while (true)
        { 
            // изменение состояния света на обратное через 0.5 секунд
            light.SetActive(!light.activeSelf);
            yield return new WaitForSeconds(0.5f);
        }
        {
            
        }
        light.SetActive(true);

    }
}
