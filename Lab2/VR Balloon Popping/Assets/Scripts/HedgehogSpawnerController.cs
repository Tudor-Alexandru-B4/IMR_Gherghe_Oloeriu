using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogSpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    CounterController counterController;

    // Start is called before the first frame update
    void Start()
    {
        counterController = GameObject.Find("Counter").GetComponent<CounterController>();
        SpawnHedgehog();
    }

    public void SpawnHedgehog()
    {
        Instantiate(prefab, transform);
        counterController.UpdateCurrentThrowsCount();
    }
}
