using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//For dif text files, Change everything with "Change"

public class Dialogue1 : MonoBehaviour
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
    public Sprite ZachWorried, ZachCry;


    public bool nextLevel = false;

    void Start()
    {
        SpriteRenderer RenderOne = GameObject.Find("CharacterOne").GetComponent<SpriteRenderer>(); //Change Name

        txt = GameObject.Find("Dialogue").GetComponent<Text>();
        txt.text = asset.text;

        txt2 = GameObject.Find("Name").GetComponent<Text>();
        Debug.Log(txt2);
        txt2.text = people.text;
        Debug.Log(txt2);

        theSourceFile = new FileInfo("Assets/Scripts/TextDialogue/Dialogue1.txt"); //Change File name
        reader = theSourceFile.OpenText();

        PeopleSourceFile = new FileInfo("Assets/Scripts/TextDialogue/Dialogue1People.txt"); //Change File name
        reader2 = PeopleSourceFile.OpenText();

        text = reader.ReadLine();
        topText = reader2.ReadLine();

        txt.text = text;
        txt2.text = topText;

        if (topText == "Zacharias")
        {
            RenderOne.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            RenderOne.color = new Color(.5f, .5f, .5f, 1f);
        }
    }

    void Update()
    {
        SpriteRenderer RenderOne = GameObject.Find("CharacterOne").GetComponent<SpriteRenderer>(); //Change Name
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

                if (text == "Woah, are you okay? You don't look too well.")
                {
                    RenderOne.sprite = ZachWorried;
                }
                if (text == "Wait, Mom, wake up! I'll do anything! Tell me what to do! I'll get food, anything! I can't... ")
                {
                    RenderOne.sprite = ZachCry;
                }
                if (topText == "Zacharias")
                {
                    RenderOne.color = new Color(1f, 1f, 1f, 1f);
                }
                else
                {
                    RenderOne.color = new Color(.5f, .5f, .5f, 1f);
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
            SceneManager.LoadScene("Dialogue2");
            nextLevel = true;
        }
    }
}