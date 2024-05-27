using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    [SerializeField]private float bulletSpeed;
    Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();  
        rigidBody2D.velocity = Vector2.down * Time.deltaTime*bulletSpeed;  
        Invoke("DestroyBullets",8f);
    }

    private void DestroyBullets()
    {
        Destroy(gameObject);
    }

}
