using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDeath : MonoBehaviour {

    public Health health;
    public GameObject death;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (health.currentHealth == 0)
        {
            Debug.Log("Should have DEATHSCREEN");
            death.SetActive(true);
            Time.timeScale = 0;
        }
		
	}
}
