using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    Rigidbody2D MyRigidbody;
    PlayerMovement player;
    float xSpeed;
    
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        MyRigidbody.velocity = new Vector2 (xSpeed, 0f);
    }


   
  
     void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enermy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
     void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);    
    }

}
