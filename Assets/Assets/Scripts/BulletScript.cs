using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
     Rigidbody2D rigidBody2D;
    [SerializeField] private float bulletSpeed;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        rigidBody2D.velocity = Vector2.up * Time.deltaTime*bulletSpeed;

        Invoke("Destroybullet",4f);      
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<EnemyBullets>()!=null)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
        else if(other.gameObject.CompareTag("BulletDestroy"))
        {
            Destroy(gameObject);
        }
        else if(other.GetComponent<TorpedoScript>() != null)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
    private void Destroybullet()
    {
        Destroy(gameObject);

    }
}
