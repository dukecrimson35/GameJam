using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSerch : MonoBehaviour
{
    public GameObject Shark;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //�T����ǂ��������[�h��
            Debug.Log("ss");
        }

    }
}
