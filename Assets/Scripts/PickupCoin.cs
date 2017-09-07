using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupCoin : MonoBehaviour
{
    public GemCount gems;
    public bool HasBeenCollected = false;
    public AudioClip pickUpSound1;
    public AudioClip pickUpSound2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (HasBeenCollected == false)
            {
                HasBeenCollected = true;
                Destroy(gameObject);
                gems.ChangeGemCount();
                SoundManager.instance.RandomizeSfx(pickUpSound1);
            }

        }
    }
}
