using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSerch : MonoBehaviour
{
    public GameObject Shark;
    SharkMove sharkMove;
    // Start is called before the first frame update
    void Start()
    {
        sharkMove = Shark.GetComponent<SharkMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //ÉTÉÅÇí«Ç¢Ç©ÇØÉÇÅ[ÉhÇ…
            sharkMove.ChangeHuntmode();
            sharkMove.GetHirame(other.gameObject);
            sharkMove.GetHirameScript(other.gameObject);
        }

    }
}
