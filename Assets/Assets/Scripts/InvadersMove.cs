using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class InvadersMove : MonoBehaviour
{
    [SerializeField] private float invaderSpeed;
    [SerializeField] private float invaderVericalMovement;
    private float dir=1;

    [SerializeField] private GameObject enemyBullets;
    [SerializeField] private float Xmax;
    [SerializeField] private float Xmin;
    [SerializeField] private float Ymax;
    [SerializeField] private float Ymin;
    [SerializeField] private float InstantiationTimer;
    private float FixedTimer;


    void Start()
    {
        // InvokeRepeating("EnemyBulletFire",2f,2f);
        // InvokeRepeating("PowerUps",5f,5f);
        FixedTimer=InstantiationTimer;
    }

    void Update()
    {
        transform.Translate(dir * invaderSpeed * Time.deltaTime,0,0);
        CreateBullet();
    }

    private void CreateBullet()
    {
        InstantiationTimer -= Time.deltaTime;
	    if (InstantiationTimer <= 0)
        {
            float X = Random.Range(Xmax,Xmin);
            float Y = Random.Range(Ymax,Ymin);  
            Vector3 enemyBulletPos =  new Vector3(X,Y,0f);     
            Instantiate(enemyBullets,enemyBulletPos,quaternion.identity);
            InstantiationTimer = FixedTimer;

        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
     if (other.gameObject.CompareTag("Boundary"))
        {
            dir=-dir;
            transform.Translate(0,invaderVericalMovement *-1* Time.deltaTime,0);
        }
        
    }

    // void EnemyBulletFire()
    // {
    //     float X = Random.Range(Xmax,Xmin);
    //     float Y = Random.Range(Ymax,Ymin);  
    //     Vector3 enemyBulletPos =  new Vector3(X,Y,0f);     
    //     Instantiate(enemyBullets,enemyBulletPos,quaternion.identity);
    // }


}
