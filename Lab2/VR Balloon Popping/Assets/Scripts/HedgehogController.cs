using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogController : MonoBehaviour
{
    [SerializeField]
    float distanceFromSpawnPoint;
    bool spawnedNewHedgehog = false;
    GameObject mainCamera;
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawnedNewHedgehog && Vector3.Distance(spawnPosition, transform.position) > distanceFromSpawnPoint)
        {
            SpawnNewHedgehog();
        }
        transform.LookAt(new Vector3(mainCamera.transform.position.x, transform.position.y, mainCamera.transform.position.z));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            if (!spawnedNewHedgehog)
            {
                SpawnNewHedgehog();
            }
            Destroy(gameObject);
        }
    }

    private void SpawnNewHedgehog()
    {
        spawnedNewHedgehog = true;
        GameObject.Find("HedgehogSpawner").GetComponent<HedgehogSpawnerController>().SpawnHedgehog();
    }

}
