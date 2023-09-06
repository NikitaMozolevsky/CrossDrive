using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCoins : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
