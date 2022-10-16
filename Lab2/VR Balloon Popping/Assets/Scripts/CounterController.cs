using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterController : MonoBehaviour
{
    [SerializeField]
    int startingThrowsCount;
    int throwsLeftCount;
    TextMeshPro tmpro;

    // Start is called before the first frame update
    void Start()
    {
        tmpro = gameObject.GetComponent<TextMeshPro>();
        throwsLeftCount = startingThrowsCount;
        tmpro.text = "Throws left: " + startingThrowsCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(throwsLeftCount <= 0)
        {
            GameObject.Find("GameOver").SetActive(true);
        }
    }

    public void UpdateCurrentThrowsCount()
    {
        throwsLeftCount--;
        tmpro.text = "Throws left: " + throwsLeftCount;
    }

    public int GetThrowsLeftCount()
    {
        return throwsLeftCount;
    }
}
