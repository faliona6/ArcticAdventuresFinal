using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//For dif text files, Change everything with "Change"

public class Dialogue6 : MonoBehaviour
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

    public Sprite PetraEmberrased, PetraHappy, PetraNeutral;
    public Sprite ZachHappy, ZachNeutral, ZachSad;
    public Sprite StanHappy, StanSad;

    public bool nextLevel = false;

    void Start()
    {
        SpriteRenderer RenderOne = GameObject.Find("CharacterOne").GetComponent<SpriteRenderer>(); //Change Name
        SpriteRenderer RenderTwo = GameObject.Find("CharacterTwo").GetComponent<SpriteRenderer>(); //Change Name
        SpriteRenderer RenderThree = GameObject.Find("CharacterThree").GetComponent<SpriteRenderer>(); //Change Name

        txt = GameObject.Find("Dialogue").GetComponent<Text>();
        txt.text = asset.text;

        txt2 = GameObject.Find("Name").GetComponent<Text>();
        Debug.Log(txt2);
        txt2.text = people.text;
        Debug.Log(txt2);

        theSourceFile = new FileInfo("Assets/Scripts/TextDialogue/Dialogue6.txt"); //Change File name
        reader = theSourceFile.OpenText();

        PeopleSourceFile = new FileInfo("Assets/Scripts/TextDialogue/Dialogue6People.txt"); //Change File name
        reader2 = PeopleSourceFile.OpenText();

        text = reader.ReadLine();
        topText = reader2.ReadLine();

        txt.text = text;
        txt2.text = topText;

        if (topText == "Zacharias")
        {
            RenderOne.color = new Color(1f, 1f, 1f, 1f);
            RenderTwo.color = new Color(.5f, .5f, .5f, 1f);
            RenderThree.color = new Color(.5f, .5f, .5f, 1f);
        }
        else if (topText == "Petra")
        {
            RenderOne.color = new Color(.5f, .5f, .5f, 1f);
            RenderTwo.color = new Color(1f, 1f, 1f, 1f);
            RenderThree.color = new Color(.5f, .5f, .5f, 1f);
        }
        else if (topText == "Stan")
        {
            RenderOne.color = new Color(.5f, .5f, .5f, 1f);
            RenderTwo.color = new Color(.5f, .5f, .5f, 1f);
            RenderThree.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            RenderOne.color = new Color(.5f, .5f, .5f, 1f);
            RenderTwo.color = new Color(.5f, .5f, .5f, 1f);
            RenderThree.color = new Color(.5f, .5f, .5f, 1f);
        }

    }

    void Update()
    {
        SpriteRenderer RenderOne = GameObject.Find("CharacterOne").GetComponent<SpriteRenderer>(); //Change Name
        SpriteRenderer RenderTwo = GameObject.Find("CharacterTwo").GetComponent<SpriteRenderer>(); //Change Name
        SpriteRenderer RenderThree = GameObject.Find("CharacterThree").GetComponent<SpriteRenderer>(); //Change Name

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
                if (text == "The crabs will stop searching for oil in the Arctic, and we'll be saved!")
                {
                    RenderTwo.sprite = PetraHappy;
                }
                if (text == "But... I guess this is goodbye then. ")
                {
                    RenderTwo.sprite = PetraNeutral;
                }
                if (text == "You guys!! I'll miss you guys so much. Like, we've had so many memories together!")
                {
                    RenderThree.sprite = StanSad;
                }
                if ( text == "No problem. You guys helped me destroy Crab Corps! That's pretty amazing. ")
                {
                    RenderTwo.sprite = PetraHappy;
                }
                if (text == "I agree!! We did something quite amazing, huh.")
                {
                    RenderThree.sprite = StanHappy;
                }
                if (text == "Cool. ") {
                    RenderOne.sprite = ZachHappy;
                }
                //Color
                if (topText == "Zacharias")
                {
                    RenderOne.color = new Color(1f, 1f, 1f, 1f);
                    RenderTwo.color = new Color(.5f, .5f, .5f, 1f);
                    RenderThree.color = new Color(.5f, .5f, .5f, 1f);
                }
                else if (topText == "Petra")
                {
                    RenderOne.color = new Color(.5f, .5f, .5f, 1f);
                    RenderTwo.color = new Color(1f, 1f, 1f, 1f);
                    RenderThree.color = new Color(.5f, .5f, .5f, 1f);
                }
                else if (topText == "Stan")
                {
                    RenderOne.color = new Color(.5f, .5f, .5f, 1f);
                    RenderTwo.color = new Color(.5f, .5f, .5f, 1f);
                    RenderThree.color = new Color(1f, 1f, 1f, 1f);
                }
                else
                {
                    RenderOne.color = new Color(.5f, .5f, .5f, 1f);
                    RenderTwo.color = new Color(.5f, .5f, .5f, 1f);
                    RenderThree.color = new Color(.5f, .5f, .5f, 1f);
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
            SceneManager.LoadScene("MainMenuScene");
            nextLevel = true;
        }
    }
}