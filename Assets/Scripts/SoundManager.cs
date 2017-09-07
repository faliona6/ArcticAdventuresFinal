using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
    public AudioSource moosic;
    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.           
    public float lowPitchRange = .97f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.03f;            //The highest a sound effect will be randomly pitched.

    public AudioClip LevelMusic;
    public AudioClip Level1Music;
    public AudioClip Level2Music;
    public AudioClip Dialogue0;
    public AudioClip DialogueMomDead;
    public AudioClip DialogueHouseDead;
    public AudioClip DialogueRecruitStan;
    public AudioClip DialogueDiscuss;
    public AudioClip DialogueRecruitPetra;
    public AudioClip DialogueDestroyTheWorld;
    public AudioClip MenuMusic;

    private int potato;
    private int tomato;
  
    void Awake()
    {
        tomato = -1;
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);
        

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();
    }


    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(params AudioClip[] clips)
    {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, clips.Length);

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        efxSource.pitch = randomPitch;

        //Set the clip to the clip at our randomly chosen index.
        efxSource.clip = clips[randomIndex];

        //Play the clip.
        efxSource.Play();
    }

    public void SwitchAudioClip()
    {
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            moosic.clip = MenuMusic;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue0")
        {
            moosic.clip = Dialogue0;
        }
        else if (SceneManager.GetActiveScene().name == "Level1")
        {
            moosic.clip = Level1Music;
            Debug.Log("drop the beets");
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            moosic.clip = Level2Music;
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            moosic.clip = LevelMusic;
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            moosic.clip = LevelMusic;
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            moosic.clip = LevelMusic;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue1")
        {
            moosic.clip = DialogueMomDead;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue2")
        {
            moosic.clip = DialogueHouseDead;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue3")
        {
            moosic.clip = DialogueRecruitStan;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue4")
        {
            moosic.clip = DialogueDiscuss;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue5")
        {
            moosic.clip = DialogueRecruitPetra;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue6")
        {
            moosic.clip = DialogueDestroyTheWorld;
        }
        moosic.Play();
        Debug.Log("music played");
    }

    // check if you actually need to change the music
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            potato = 0;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue0")
        {
            potato = 10;
        }
        else if (SceneManager.GetActiveScene().name == "Level1")
        {
            potato = 8;
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            potato = 9;
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            potato = 1;
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            potato = 1;
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            potato = 1;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue1")
        {
            potato = 2;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue2")
        {
            potato = 3;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue3")
        {
            potato = 4;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue4")
        {
            potato = 5;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue5")
        {
            potato = 6;
        }
        else if (SceneManager.GetActiveScene().name == "Dialogue6")
        {
            potato = 7;
        }
        if (potato != tomato){
            SwitchAudioClip();
        }
        tomato = potato;
    }
}