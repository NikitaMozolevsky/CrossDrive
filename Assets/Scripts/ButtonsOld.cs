using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsOld : MonoBehaviour
{
    
    // для вдавливания кнопки
    public Sprite button, pressed;
    public bool music;

    private Image img;
    private float yPos;
    private Transform child;

    private void Start()
    {
        PlayerPrefs.DeleteAll ();

        img = GetComponent <Image> (); 
        child = transform.GetChild (0).transform;

        if (music) {
            if (PlayerPrefs.GetString ("Music") != "no") { // Музыка сейчас играет и мы можем её выключить
                transform.GetChild (0).gameObject.SetActive (true);
                transform.GetChild (1).gameObject.SetActive (false);
            } else {
                transform.GetChild (0).gameObject.SetActive (false);
                transform.GetChild (1).gameObject.SetActive (true);
                child = transform.GetChild (1).transform;
            }
        }
    }

    private void OnMouseDown()
    { // Source image
        img.sprite = pressed;
        yPos = child.localPosition.y;
        child.localPosition = new Vector3(child.localPosition.x, 0, child.localPosition.z);
    }

    void OnMouseUp()
    {
        img.sprite = button;
        child.localPosition = new Vector3(child.localPosition.x, yPos, child.localPosition.z);
    }
}
