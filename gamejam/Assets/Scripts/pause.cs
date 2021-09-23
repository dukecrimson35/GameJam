using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    //[SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    //[SerializeField] private Button resumeButton;
    GameObject obj;
    GameObject Menu;

    void Start()
    {
        pausePanel.SetActive(false);
        //Menu = GameObject.Find("Menu");
        //obj = (GameObject)Instantiate(pausePanel, this.transform.position, Quaternion.identity);
        //obj.transform.parent = Menu.transform;
        //obj.SetActive(false);
        //pauseButton.onClick.AddListener(Pause);
        //resumeButton.onClick.AddListener(Resume);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.P))
        {
            Pause();

        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Resume();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;  // éûä‘í‚é~
        pausePanel.SetActive(true);
    }

    private void Resume()
    {
        Time.timeScale = 1;  // çƒäJ
        pausePanel.SetActive(false);
    }
}
