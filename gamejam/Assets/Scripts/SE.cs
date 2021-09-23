using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;

    AudioSource audioSource;
    GameObject hirame;
    HirameMove script;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        hirame = GameObject.Find("Hirame");
        script = hirame.GetComponent<HirameMove>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
