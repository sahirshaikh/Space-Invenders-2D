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
    [SerializeField] private float xMax;
    [SerializeField] private float xMin;
    [SerializeField] private float yMax;
    [SerializeField] private float yMin;
    [SerializeField] private float instantiationTimer;
    private float fixedTimer;
    void Start()
    {
        fixedTimer=instantiationTimer;
    }

    void Update()
    {
        transform.Translate(dir * invaderSpeed * Time.deltaTime,0,0);
        CreateBullet();
    }

    private void CreateBullet()
    {
        instantiationTimer -= Time.deltaTime;
	    if (instantiationTimer <= 0)
        {
            float X = Random.Range(xMax,xMin);
            float Y = Random.Range(yMax,yMin);  
            Vector3 enemyBulletPos =  new Vector3(X,Y,0f);     
            Instantiate(enemyBullets,enemyBulletPos,quaternion.identity);
            instantiationTimer = fixedTimer;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
     if (other.gameObject.GetComponent<Boundry>()!=null)
        {
            dir=-dir;
            transform.Translate(0,invaderVericalMovement *-1* Time.deltaTime,0);
        }
        
    }
}
