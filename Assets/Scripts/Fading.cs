using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{

    public Texture2D fadeOutTexture;
    
    private float fadeSpeed = 0.8f;
    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDirection = -1;

    private void OnGUI()
    {
        // затухание
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        // для того что бы alpha имело згачение от 0 до 1
        // 0 - прозначный, 1 - непрозрачный
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth; 
        // ширина и высота на весь экран
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    // установка затухнания либо высветления по параметру функции
    // возвращает скоростть затухания
    public float BeginFade(int direction) 
    {
        fadeDirection = direction;
        return fadeSpeed;
    }

    // запускается как только произошол переход на новую сцену
    // ставится на камеру
    private void OnEnable() 
    {
        BeginFade(-1); // переход от черного экрана к прозначному
    }
}
