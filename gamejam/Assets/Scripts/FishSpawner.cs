using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject Fish;//���ݏo������
    public int spawnTime;//�����Ԋu

    float count;//�^�C�}�[

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count >= spawnTime)
        {
            Instantiate(Fish);
            count = 0;
        }
    }
}
