using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource moosic;

    public AudioClip[] soundtrack;
    public static MusicManager instance = null;

    // Use this for initialization
    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        Debug.Log(SceneManager.GetActiveScene().name);
        soundtrack = new AudioClip[8];
        soundtrack[0] = (AudioClip)Resources.Load("LevelMusic");
        soundtrack[1] = (AudioClip)Resources.Load("DialogueMomDead");
        soundtrack[2] = (AudioClip)Resources.Load("DialogueHouseDead");
        soundtrack[3] = (AudioClip)Resources.Load("DialogueRecruitStan");
        soundtrack[4] = (AudioClip)Resources.Load("DialogueDiscuss");
        soundtrack[5] = (AudioClip)Resources.Load("DialogueRecruitPetra");
        soundtrack[6] = (AudioClip)Resources.Load("DialogueDestroyTheWorld");
        soundtrack[7] = (AudioClip)Resources.Load("MenuMusic");

        SwitchAudioClip();
    }

    public void SwitchAudioClip()
    {
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            moosic.clip = soundtrack[7];
        }
        else if (SceneManager.GetActiveScene().name == "Level1")
        {
            moosic.clip = soundtrack[0];
            Debug.Log("drop the beets");
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            moosic.clip = soundtrack[0];
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            moosic.clip = soundtrack[0];
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            moosic.clip = soundtrack[0];
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            moosic.clip = soundtrack[0];
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue1")
            {
            moosic.clip = soundtrack[1];
        }
        else if(SceneManager.GetActiveScene().name == "Dialogue2")
        {
            moosic.clip = soundtrack[2];
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue3")
        {
            moosic.clip = soundtrack[3];
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue4")
        {
            moosic.clip = soundtrack[4];
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue5")
        {
            moosic.clip = soundtrack[5];
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue6")
            {
            moosic.clip = soundtrack[6];
        }
        moosic.Play();
        Debug.Log("music played");
    }
}
