using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogSpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnHedgehog();
    }

    public void SpawnHedgehog()
    {
        Instantiate(prefab, transform);
    }
}
