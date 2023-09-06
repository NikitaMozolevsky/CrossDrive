using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondStep : MonoBehaviour
{

    public TextMeshProUGUI study;

    void Start()
    {
        study.text = "Watch where the cat turns"; 
    }

    private void OnDisable()
    {
        PlayerPrefs.SetString("Study", "Done");
        SceneManager.LoadScene("game");
    }
}
