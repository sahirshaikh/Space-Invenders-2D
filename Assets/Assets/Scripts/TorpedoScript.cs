using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour
{
    [SerializeField]private float torpedoSpeed;
    Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();  
        rigidBody2D.velocity = Vector2.down * Time.deltaTime*torpedoSpeed;  
        Invoke("DestroyTorpedo",8f);
    }

    private void DestroyTorpedo()
    {
        Destroy(gameObject);
    }

}
