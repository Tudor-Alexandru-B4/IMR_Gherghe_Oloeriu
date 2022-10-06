using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusDetecter : MonoBehaviour
{

    [SerializeField]
    CactusAnimationController cactus;
    [SerializeField]
    GameObject parent;
    int cactiCount;

    // Start is called before the first frame update
    void Start()
    {
        cactiCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cactiCount <= 0)
        {
            //System.Console.WriteLine("Should Idle");
            cactus.AnimationIdle();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Should Attack");

        if (other.gameObject.tag == "SpawnableObjectTag" && !GameObject.ReferenceEquals(other.gameObject, parent))
        {
            System.Console.WriteLine("Should Attack");
            cactiCount++;
            cactus.AnimationAttack();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SpawnableObjectTag")
        {
            cactiCount--;
        }
    }


}
