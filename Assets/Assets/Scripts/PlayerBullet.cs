using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
     Rigidbody2D rigidBody2D;
    [SerializeField] private float bulletSpeed;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();  
        rigidBody2D.velocity = Vector2.up * Time.deltaTime*bulletSpeed;  
        Invoke("DestroyBullet",4f);      
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if((other.GetComponent<EnemyBullet>()!=null)||(other.GetComponent<Torpedo>() != null))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
