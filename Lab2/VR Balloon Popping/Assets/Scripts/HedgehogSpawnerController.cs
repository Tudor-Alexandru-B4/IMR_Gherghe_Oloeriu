using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (counterController.GetThrowsLeftCount() > 0)
        {
            Instantiate(prefab, transform);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
