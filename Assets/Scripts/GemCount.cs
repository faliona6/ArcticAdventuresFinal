using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GemCount : MonoBehaviour {

    Text txt;
    public int gems;
    private int gems2;
    public GlobalControl global;

    // Use this for initialization
    void Awake () {
        txt = GameObject.Find("MainText").GetComponent<Text>();
        txt.text = "Gems: " + gems;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateScore() {
    }

    public void ChangeGemCount() {
        gems2 = gems;
        gems2 += 1;
        gems += 1;
        txt.text = "Gems: " + gems;
    }
}
