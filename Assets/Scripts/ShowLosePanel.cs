using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowLosePanel : MonoBehaviour
{

    [SerializeField]
    private GameObject losePanel, slowTime;
    public bool atOnce;

    void Update()
    {
        if (CollisionCars.lose && !atOnce)
        {
            atOnce = true;
            slowTime.SetActive(false);
            losePanel.SetActive(true);

        }
    }

}
