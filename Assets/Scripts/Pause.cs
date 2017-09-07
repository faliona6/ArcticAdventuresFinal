using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                //showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                //hidePaused();
            }
        }
        Debug.Log(Time.timeScale);
    }
    //Reloads the Level
    public void Reload()
    {
        //Application.LoadLevel(Application.loadedLevel);
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        GameObject.Find("PausePanel").SetActive(true);

    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        GameObject.Find("PausePanel").SetActive(false);
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        //Application.LoadLevel(level);
    }
}
