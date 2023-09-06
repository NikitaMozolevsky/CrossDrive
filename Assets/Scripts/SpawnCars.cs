using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCars : MonoBehaviour
{

    // массив всех машинок которые можно запускать/создавать
    public GameObject[] cars; 
    private float startSpawn = 0.5f; // время после кторого начианет ехать машинка
    private float waitSpawn; // время после кторого создается новая машинка
    private bool onceStop = false; // позволяет выполнить операцию только один раз (непонятен смысл если есть lose)
    [SerializeField] // переменная будет видна в инспекторе, но не в других местах
    public bool isMenu;
    
    private int countCars = 0; 

    private void Start()
    {
        StartCoroutine(WestCars());
        StartCoroutine(EastCars());
        StartCoroutine(NorthCars());
        StartCoroutine(SouthCars());

        waitSpawn = isMenu ? 7f : 3f;
        
        // при перезапуске игры lose = false
        CollisionCars.lose = false;
    }

    private void Update() // если больше 20 машинок время спавна сокращается
    {
        if (!isMenu)
        {
            if (countCars > 60)
            {
            waitSpawn = 4f;
            }
            else if (countCars > 40)
            {
            waitSpawn = 5f;
            }
            else if (countCars > 20)
            {
            waitSpawn = 6f;
            }
        }

        if (CollisionCars.lose && !onceStop) // остановка игры, onceStop для прекращения постоянной остновки куратины
        {
            StopAllCoroutines();
            onceStop = true;
        }
        
    }

    IEnumerator WestCars() 
    { // ожидание в диапазоне
        yield return new WaitForSeconds(Random.Range(startSpawn, startSpawn + 4.5f));

        while (true)
        { // постоянное создание west-машинки
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], 
                new Vector3(-90.7399979f,0,2.8900001f), 
                Quaternion.Euler(0, 270, 0)) as GameObject;
            countCars++;
            int rand = isMenu ? 2 : Random.Range(0, 4); // если на главной сцене по умолчанию - 2
            switch (rand)
            {
                case 1:
                    carInst.AddComponent<WestTurnLeft>();
                    break;
                case 2:
                    carInst.AddComponent<WestTurnRight>();
                    break;
            } // в остальных 2-х случаях машинка едет прями
            // ожидание перед созданием новой машинки
            yield return new WaitForSeconds(Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }
    
    IEnumerator EastCars() 
    { // ожидание в диапазоне
        yield return new WaitForSeconds(Random.Range(startSpawn, startSpawn + 4.5f));

        while (true)
        { // постоянное создание west-машинки
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], 
                new Vector3(33.5200005f,0,9.96000004f), 
                Quaternion.Euler(0, 90, 0)) as GameObject;
            countCars++;
            int rand = isMenu ? 2 : Random.Range(0, 4);
            switch (rand)
            {
                case 1:
                    carInst.AddComponent<EastTurnLeft>();
                    break;
                case 2:
                    carInst.AddComponent<EastTurnRight>();
                    break;
            } // в остальных 2-х случаях машинка едет прями
            // ожидание перед созданием новой машинки
            yield return new WaitForSeconds(Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }
    
    IEnumerator NorthCars() 
    { // ожидание в диапазоне
        yield return new WaitForSeconds(Random.Range(startSpawn, startSpawn + 4.5f));

        while (true)
        { // постоянное создание west-машинки
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], 
                new Vector3(1.66999996f,0,64.5999985f), 
                Quaternion.Euler(0, 0, 0)) as GameObject;
            countCars++;
            int rand = isMenu ? 2 : Random.Range(0, 4);
            switch (rand)
            {
                case 1:
                    carInst.AddComponent<NorthTurnLeft>();
                    break;
                case 2:
                    carInst.AddComponent<NorthTurnRight>();
                    break;
            } // в остальных 2-х случаях машинка едет прями
            // ожидание перед созданием новой машинки
            yield return new WaitForSeconds(Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }
    
    IEnumerator SouthCars() 
    { // ожидание в диапазоне
        yield return new WaitForSeconds(Random.Range(startSpawn, startSpawn + 4.5f));

        while (true)
        { // постоянное создание west-машинки
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], 
                new Vector3(8.97999954f,0,-26.7999992f), 
                Quaternion.Euler(0, 180, 0)) as GameObject;
            countCars++;
            int rand = isMenu ? 2 : Random.Range(0, 4);
            switch (rand)
            {
                case 1:
                    carInst.AddComponent<SouthTurnLeft>();
                    break;
                case 2:
                    carInst.AddComponent<SouthTurnRight>();
                    break;
            } // в остальных 2-х случаях машинка едет прями
            // ожидание перед созданием новой машинки
            yield return new WaitForSeconds(Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }
}
