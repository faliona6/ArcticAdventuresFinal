using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//For dif text files, Change everything with "Change"

public class Dialogue0 : MonoBehaviour
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
    SpriteRenderer RenderOne;

    public bool nextLevel = false;

    void Start()
    {
        txt = GameObject.Find("Dialogue").GetComponent<Text>();
        txt.text = asset.text;

        txt2 = GameObject.Find("Name").GetComponent<Text>();
        Debug.Log(txt2);
        txt2.text = people.text;
        Debug.Log(txt2);

        theSourceFile = new FileInfo("Assets/Scripts/TextDialogue/Dialogue0.txt"); //Change File name
        reader = theSourceFile.OpenText();

        PeopleSourceFile = new FileInfo("Assets/Scripts/TextDialogue/Dialogue0People.txt"); //Change File name
        reader2 = PeopleSourceFile.OpenText();

        text = reader.ReadLine();
        topText = reader2.ReadLine();

        txt.text = text;
        txt2.text = topText;
    }

    void Update()
    {
        
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
            SceneManager.LoadScene("Level1");
            nextLevel = true;
        }
    }
}