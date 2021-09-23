using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishmator : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
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
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = script.fishcount+"匹食べた";
    }
}
