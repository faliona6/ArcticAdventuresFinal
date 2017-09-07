using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

    public Health health;
    public GameObject pause;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }

    }
    void Pause ()
    {
        if (Time.timeScale == 1)
        {
            pause.SetActive(true);
            Debug.Log("WHWYWYWYWY?");
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            pause.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
