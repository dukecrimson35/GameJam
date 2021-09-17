using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject Fish;//生み出すもの

    public int count;//タイマー

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count >= 60*5)
        {
            Instantiate(Fish);
            count = 0;
        }
    }
}
