using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(MoveCar))]
public class Acceleration : MonoBehaviour
{

    private bool isAccelerated = false;
    public GameObject exhaust;
    

    private void OnMouseDown()
    {
        if (!isAccelerated)
        {
            GetComponent<MoveCar>().speed *= 2f;
            isAccelerated = true;
            
            GameObject ex = Instantiate(exhaust,
                new Vector3(gameObject.transform.position.x, 0.2f, gameObject.transform.position.z),
                Quaternion.Euler(new Vector3(90, 0, 0))) as GameObject;
            
            Destroy(ex, 1f);
        }
    }
}
