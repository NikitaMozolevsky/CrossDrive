using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public Sprite button, pressed;
    public bool music;
    private Image img;
    private float yPos;
    private Transform child;

    private void Start()
    {
        img = GetComponent<Image>();
        // берем первый дочерний элемент объекта на котором скрипт (кнопка)
        child = transform.GetChild(0).transform;
        
        if (music)
        {
            if (PlayerPrefs.GetString("Music") != "no")
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                child = transform.GetChild(1).transform;
            }
        }
    }

    private void OnMouseDown()
    {
        img.sprite = pressed;
        yPos = child.localPosition.y;
        // устанавливается 0 по y относительно новой кнопки
        child.localPosition = new Vector3(child.localPosition.x, 0, child.localPosition.z);
    }

    private void OnMouseUp()
    {
        img.sprite = button;
        child.localPosition = new Vector3(0, yPos, 0);
    }

    private void OnMouseUpAsButton() //нажали кнопку и отжали на этой кнопке
    {
        switch (gameObject.name)
        {
            case "Play":
                string scene = PlayerPrefs.HasKey("Study") ? "game" : "study";
                // если кнопка Play начинается куратина
                StartCoroutine(LoadScene(scene));
                break;
            
            case "Replay":
                // если кнопка Play начинается куратина
                StartCoroutine(LoadScene("game"));
                break;
            
            case "Home":
                // если кнопка Play начинается куратина
                StartCoroutine(LoadScene("menu"));
                break;
            
            case "HowTo":
                StartCoroutine(LoadScene("study"));
                break;
            
            case "Shop":
                StartCoroutine(LoadScene("shop"));
                break;
            
            case "Close":
                StartCoroutine(LoadScene("menu"));
                break;
                
            case "Music":
                child.gameObject.SetActive(false); // отключение объекта
                if (PlayerPrefs.GetString("Music") != "no")
                {
                    PlayerPrefs.SetString("Music", "no"); // работа с сессией
                    child = transform.GetChild(1).transform; // установка второй картинки
                }
                else
                {
                    PlayerPrefs.DeleteKey("Music");
                    child = transform.GetChild(0).transform;
                }
                child.gameObject.SetActive(true);
                break;
        }
    }

    IEnumerator LoadScene(string scene)
    {
        // затемнение экрана и ожидание завершения этого
        // запуск функции класса Fading 
        float fadeTime = Camera.main.GetComponent<Fading>().BeginFade(1); 
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(scene);
    }
}
