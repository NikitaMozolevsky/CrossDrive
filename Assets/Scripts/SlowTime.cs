using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlowTime : MonoBehaviour
{

    private TextMeshProUGUI countSlow;
    public Sprite active, inactive;
    private void Start()
    {
        countSlow = gameObject.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>();
        if (!PlayerPrefs.HasKey("SlowTime"))
        {
            PlayerPrefs.SetInt("SlowTime", 2);
            countSlow.text = "2";
        }
        else
        {
            countSlow.text = PlayerPrefs.GetInt("SlowTime").ToString();
        }

        if (PlayerPrefs.GetInt("SlowTime") == 0)
        {
            GetComponent<Image>().sprite = inactive;
        }
        else
        {
            GetComponent<Image>().sprite = active;
        }
    }

    private void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("SlowTime") > 0 && Time.timeScale != 0.5f)
        {
            PlayerPrefs.SetInt("SlowTime", PlayerPrefs.GetInt("SlowTime") - 1);
            countSlow.text = PlayerPrefs.GetInt("SlowTime").ToString();
            if (PlayerPrefs.GetInt("SlowTime") == 0)
            {
                GetComponent<Image>().sprite = inactive;
            }
            StartCoroutine(Slow());
        }
    }

    IEnumerator Slow()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
    }

    private void OnDisable() // по завершении игры настройки по умолчанию
    {
        Time.timeScale = 1f;
    }
}
