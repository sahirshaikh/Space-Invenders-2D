using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    [SerializeField]private float bulletSpeed;

    private int dir =-1;

    void Update()
    {
        transform.Translate( 0, dir * bulletSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
            Debug.Log("Enemy Bullet");
        }
    }

}
