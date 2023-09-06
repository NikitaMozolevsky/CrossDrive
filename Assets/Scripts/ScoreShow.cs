using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI topResult;
    private void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + DeleteCar.countCars.ToString();
        if (PlayerPrefs.GetInt("TopScore") < DeleteCar.countCars)
        {
            PlayerPrefs.SetInt("TopScore", DeleteCar.countCars);
            topResult.text = "Top: " + DeleteCar.countCars.ToString();
            
        }
        else
        {
            topResult.text = "Top: " + PlayerPrefs.GetInt("TopScore").ToString();
        }
    }
}
