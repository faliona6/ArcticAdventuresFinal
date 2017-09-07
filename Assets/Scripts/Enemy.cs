using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private bool hasCollided;

    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 2f;
    public Vector3 pos1 = new Vector3(0f, 0f, 0f);
    public Vector3 pos2 = new Vector3(0f, 0f, 0f);

    public GameObject player;
    public Health health;

    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        //If collided with player, change health and destroy enemy
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!hasCollided)
            {
                hasCollided = true;
            }
        }
    }
}