using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSerch : MonoBehaviour
{
    public GameObject fish;
    FishMove fishMove;

    // Start is called before the first frame update
    void Start()
    {
        fishMove = fish.GetComponent<FishMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //���𓦑����[�h��
            fishMove.ChangeRunmode();
            fishMove.GetHirame(other.gameObject);
            fishMove.GetHirameScript(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            //����ʏ탂�[�h��
            fishMove.ChangeRelaxmode();
        }
    }
}
