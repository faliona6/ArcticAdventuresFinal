using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//For dif text files, Change everything with "Change"

public class Dialogue5 : MonoBehaviour
{
    protected FileInfo theSourceFile = null;
    protected FileInfo PeopleSourceFile = null;
    protected StreamReader reader = null;
    protected StreamReader reader2 = null;
    protected string text = " "; // assigned to allow first line to be read below
    protected string topText = " ";
    public TextAsset asset;
    public TextAsset people;
    Text txt;
    Text txt2;

    public Sprite PetraEmberrased;
    public Sprite PetraHappy;
    public Sprite PetraNeutral;

    public bool nextLevel = false;

    void Start()
    {
        SpriteRenderer RenderOne = GameObject.Find("CharacterOne").GetComponent<SpriteRenderer>(); //Change Name
        SpriteRenderer RenderTwo = GameObject.Find("CharacterTwo").GetComponent<SpriteRenderer>(); //Change Name

        txt = GameObject.Find("Dialogue").GetComponent<Text>();
        txt.text = asset.text;

        txt2 = GameObject.Find("Name").GetComponent<Text>();
        Debug.Log(txt2);
        txt2.text = people.text;
        Debug.Log(txt2);

        theSourceFile = new FileInfo("Assets/Scripts/TextDialogue/Dialogue5.txt"); //Change File name
        reader = theSourceFile.OpenText();

        PeopleSourceFile = new FileInfo("Assets/Scripts/TextDialogue/Dialogue5People.txt"); //Change File name
        reader2 = PeopleSourceFile.OpenText();

        text = reader.ReadLine();
        topText = reader2.ReadLine();

        txt.text = text;
        txt2.text = topText;

        if (topText == "Zacharias")
        {
            RenderOne.color = new Color(1f, 1f, 1f, 1f);
            RenderTwo.color = new Color(.5f, .5f, .5f, 1f);
        }
        else if (topText == "Petra")
        {
            RenderOne.color = new Color(.5f, .5f, .5f, 1f);
            RenderTwo.color = new Color(1f, 1f, 1f, 1f);
        }

        else
        {
            RenderOne.color = new Color(.5f, .5f, .5f, 1f);
            RenderTwo.color = new Color(.5f, .5f, .5f, 1f);
        }

    }

    void Update()
    {
        SpriteRenderer RenderOne = GameObject.Find("CharacterOne").GetComponent<SpriteRenderer>(); //Change Name
        SpriteRenderer RenderTwo = GameObject.Find("CharacterTwo").GetComponent<SpriteRenderer>(); //Change Name

        if (text != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(txt);
                text = reader.ReadLine();
                topText = reader2.ReadLine();
                txt.text = text;
                txt2.text = topText;
                Debug.Log(txt);

                //Expressions
                if (text == "You know... because we have this mutual loss in our hearts... maybe we can use eachother to fill that part up...")
                {
                    RenderTwo.sprite = PetraEmberrased;
                }
                if (text == "Anyways, our goal is the same. I want to defeat the Crab Corps too in order to avenge my parents.")
                {
                    RenderTwo.sprite = PetraNeutral;
                }
                if (text == "Wait wai- I'm not talking about that anymore... Just take me with you. I can glide through the sky and help you reach places ")
                {
                    RenderTwo.sprite = PetraEmberrased;
                }
                if (text == "Okay fine. I don't mind you joining our team.")
                {
                    RenderTwo.sprite = PetraHappy;
                }
                //Color
                if (topText == "Zacharias")
                {
                    RenderOne.color = new Color(1f, 1f, 1f, 1f);
                    RenderTwo.color = new Color(.5f, .5f, .5f, 1f);
                }
                else if (topText == "Petra")
                {
                    RenderOne.color = new Color(.5f, .5f, .5f, 1f);
                    RenderTwo.color = new Color(1f, 1f, 1f, 1f);
                }

                else
                {
                    RenderOne.color = new Color(.5f, .5f, .5f, 1f);
                    RenderTwo.color = new Color(.5f, .5f, .5f, 1f);
                }
            }

        }
        else
        {
            ChangeLevel();
        }


    }

    void ChangeLevel()
    {
        if (nextLevel == false)
        {
            Debug.Log("Helloeoeoeoeo");
            SceneManager.LoadScene("Level 4");
            nextLevel = true;
        }
    }
}