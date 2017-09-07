using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class DeathTrigger : MonoBehaviour {

    public Health health;
    public GameObject death;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("TouchedPlayer");
            death.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
