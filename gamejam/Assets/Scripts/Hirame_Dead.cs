using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hirame_Dead : MonoBehaviour
{
    [SerializeField] GameObject haiboku_gazou;
    GameObject hirame;
    HirameMove script;
    // Start is called before the first frame update

    void Start()
    {
        haiboku_gazou.SetActive(false);
        hirame = GameObject.Find("Hirame");
        script = hirame.GetComponent<HirameMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(script.shiFlag == true)
        {
            Deadend();
        }
        //Deadend();
        if(haiboku_gazou == true)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
    private void Deadend()
    {
        Time.timeScale = 0;  // ŽžŠÔ’âŽ~
        haiboku_gazou.SetActive(true);
    }
}
