using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnem : MonoBehaviour
{

    public float speed;
    public bool isChasing = false;
    private Transform player;
    private int playersInRange = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Transform>();
            playersInRange++;
            isChasing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object exiting the trigger is the player
        if (other.CompareTag("Player"))
        {
            playersInRange--;
            if (playersInRange <= 0)
            {
                isChasing = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Move towards the player if chasing
        if (player != null && isChasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
