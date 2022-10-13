using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatformController : MonoBehaviour
{
    [SerializeField]
    float spawnRate;
    BalloonSpawnerController[] spawnControllers;

    // Start is called before the first frame update
    void Start()
    {
        spawnControllers = GetComponentsInChildren<BalloonSpawnerController>();
        StartCoroutine("SpawnBalloons");
    }

    IEnumerator SpawnBalloons()
    {
        while (true)
        {
            
            foreach (BalloonSpawnerController spawnController in spawnControllers)
            {
                spawnController.SpawnBalloon();
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

}
