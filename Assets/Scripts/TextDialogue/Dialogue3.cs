using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//For dif text files, Change everything with "Change"

public class Dialogue3 : MonoBehaviour
{
    protected FileInfo theSourceFile = null;
    protected FileInfo PeopleSourceFile = null;
    protected StreamReader reader = null;
    protected StreamReader reader2 = null;
    protected string text = " "; // assigned to allow first line to be read below
    protected string topText = " ";
    public TextAsset asset;
    public TextAsset people;
    public Sprite StanSad;
    public Sprite RegStan;
    public Sprite HappyZach;
    Text txt;
    Text txt2;
    SpriteRenderer RenderOne;
    SpriteRenderer RenderTwo;

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

        theSourceFile = new FileInfo("Assets/Scripts/TextDialogue/Dialogue3.txt"); //Change File name
        reader = theSourceFile.OpenText();

        PeopleSourceFile = new FileInfo("Assets/Scripts/TextDialogue/Dialogue3People.txt"); //Change File name
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
        else if (topText == "Stan")
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
        SpriteRenderer RenderOne = GameObject.Find("CharacterOne").GetComponent<SpriteRenderer>();
        SpriteRenderer RenderTwo = GameObject.Find("CharacterTwo").GetComponent<SpriteRenderer>();

        if (text != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(txt);
                text = reader.ReadLine();
                topText = reader2.ReadLine();
                txt.text = text;
                txt2.text = topText;
                Debug.Log(topText);

                //Changing Expressions

                if (text == "My... my family died because of the crabs! They killed my mother, father and baby sister!")
                {
                    RenderTwo.sprite = StanSad;
                }
                if (text == "To defeat the crabs! Let's get revenge on those bastards! ")
                {
                    RenderTwo.sprite = RegStan;
                }
                if (text == "Alright, we can go as a team. Just you and me. ")
                {
                    RenderOne.sprite = HappyZach;
                }

                //Changing Color with Who's talking

                if (topText == "Zacharias")
                {
                    RenderOne.color = new Color(1f, 1f, 1f, 1f);
                    RenderTwo.color = new Color(.5f, .5f, .5f, 1f);
                }
                else if (topText == "Stan")
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
            SceneManager.LoadScene("Dialogue4");
            nextLevel = true;
        }
    }
}