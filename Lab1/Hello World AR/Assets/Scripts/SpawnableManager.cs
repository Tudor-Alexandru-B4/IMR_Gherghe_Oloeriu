using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;

public class SpawnableManager : MonoBehaviour
{

    [SerializeField]
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    [SerializeField]
    GameObject prefab1;
    [SerializeField]
    GameObject prefab2;
    [SerializeField]
    GameObject prefab3;
    [SerializeField]
    GameObject prefab4;


    new Camera camera;
    GameObject spawnedObject;

    float initialDistance;
    Vector3 initialScale;
    bool scaling = false;




    // Start is called before the first frame update
    void Start()
    {
        spawnedObject = null;
        camera = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.GetTouch(0).position);

        if(raycastManager.Raycast(Input.GetTouch(0).position, hits))
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                if(Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "SpawnableObjectTag")
                    {
                        spawnedObject = hit.collider.gameObject;
                    }
                    else
                    {
                        SpawnPrefab(hits[0].pose.position);
                    }
                }
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = hits[0].pose.position;
            }

            if(Input.touchCount == 2)
            {
                var touchZero = Input.GetTouch(0);
                var touchOne = Input.GetTouch(1);

                if (touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled || touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled)
                {
                    goto lable_continue;
                }

                if(!scaling && spawnedObject != null)
                {
                    scaling = true;
                    initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                    initialScale = spawnedObject.transform.localScale;
                }
                else
                {
                    var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

                    if (Mathf.Approximately(initialDistance, 0))
                    {
                        goto lable_continue;
                    }

                    var factor = currentDistance / initialDistance;
                    spawnedObject.transform.localScale = initialScale * factor;

                }

            }

            lable_continue:

            if(Input.touchCount < 2 || Input.GetTouch(1).phase == TouchPhase.Ended || Input.GetTouch(1).phase == TouchPhase.Canceled)
            {
                scaling = false;
            }

            if (Input.touchCount < 1 || Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            {
                spawnedObject = null;
            }

        }


    }

    private void SpawnPrefab(Vector3 spawnPosition)
    {
        spawnedObject = Instantiate(selectPrefab(), spawnPosition, Quaternion.identity);
    }

    private GameObject selectPrefab()
    {
        int prefab = Random.Range(0, 4);

        switch (prefab)
        {
            case 0:
                return prefab1;
            case 1:
                return prefab2;
            case 2:
                return prefab3;
            default:
                return prefab4;
        }

    }

}
