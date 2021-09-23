using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hide : MonoBehaviour
{
    public GameObject hide_object = null; // Textオブジェクト
    GameObject hirame;
    HirameMove script;
    // Start is called before the first frame update
    void Start()
    {
        hirame = GameObject.Find("Hirame");
        script = hirame.GetComponent<HirameMove>();
    }

    // Update is called once per frame
    void Update()
    {
        Text hide_text = hide_object.GetComponent<Text>();
        hide_text.text = "";
        if(script.hideMater == 1)
        {
            //hirame.GetComponent<Image> ().color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
            hide_text.text = "潜伏中";
        }
    }
}
