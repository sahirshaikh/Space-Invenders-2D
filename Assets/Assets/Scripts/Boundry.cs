using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boundry : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if((other.GetComponent<PlayerBullet>() != null)||(other.GetComponent<EnemyBullet>()!=null)||(other.GetComponent<Torpedo>()!=null))
        {
            Destroy(other.gameObject);
        }
    }
  
}
