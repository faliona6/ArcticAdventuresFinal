using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{

    GameObject zach, stan, petra;
    int characterSelect;
    GameObject CurrentChar;
    public bool Trigger = false;

    //This is so that the camera follows the character
    public Camera zachCam;
    public Camera stanCam;
    public Camera petraCam;
    public Canvas canvas;

    // Use this for initialization
    void Start()
    {
        characterSelect = 1; //current character
        zach = GameObject.Find("hero");
        stan = GameObject.Find("hero2");
        petra = GameObject.Find("hero3");
        transform.position = new Vector3(-9, -20, 0);

        canvas.worldCamera = zachCam;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position; //current position of Player
        Vector3 oldPos = new Vector3(-9, -20, 0); //Empty old position vector


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Trigger = false;
            characterSelect = 1;
            oldPos = pos;
            Debug.Log(pos);
            Debug.Log("1" + oldPos);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Trigger = false;
            characterSelect = 2;
            oldPos = pos;
            Debug.Log(pos);
            Debug.Log("2" + oldPos);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Trigger = false;
            characterSelect = 3;
            oldPos = pos;
            Debug.Log(pos);
            Debug.Log("3" + oldPos);
        }


        if (characterSelect == 1)
        {
            if (Trigger == false)
            {
                zach.SetActive(true); //Activate Zach
                stan.SetActive(false);
                petra.SetActive(false);

                GameObject.Find("hero").transform.position = oldPos;

                Trigger = true; //Change trigger back to true so that it doesn't repeat more than once.

                canvas.worldCamera = zachCam;
            }

        }
        else if (characterSelect == 2)
        {
            if (Trigger == false)
            {
                zach.SetActive(false); //Activate Stan
                petra.SetActive(false);
                stan.SetActive(true);

                GameObject.Find("hero2").transform.position = oldPos; //Set Stan's position to the previous players' old position.

                Trigger = true;

                canvas.worldCamera = stanCam;
            }

        }
        else if (characterSelect == 3)
        {
            if (Trigger == false)
            {
                zach.SetActive(false); //Activate Petra
                stan.SetActive(false);
                petra.SetActive(true);

                GameObject.Find("hero3").transform.position = oldPos; //Set Stan's position to the previous players' old position.

                Trigger = true;

                canvas.worldCamera = petraCam;
            }

        }
        //Debug.Log(oldPos);
        //Debug.Log(pos);
    }
}
