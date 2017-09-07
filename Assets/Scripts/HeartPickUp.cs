using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartPickUp : MonoBehaviour {

    public Health health;
    public bool hasCollided = false;
    public AudioClip pickUpSound1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If collided with player, change health and destroy enemy
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!hasCollided)
            {
                hasCollided = true;
                health.HeartHealth(1);
                Destroy(gameObject);
                SoundManager.instance.RandomizeSfx(pickUpSound1);
            }
        }
    }
}
