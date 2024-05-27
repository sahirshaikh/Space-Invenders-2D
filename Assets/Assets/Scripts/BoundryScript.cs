using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoundryScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if((other.GetComponent<BulletScript>() != null)||(other.GetComponent<EnemyBullets>()!=null)||(other.GetComponent<TorpedoScript>()!=null))
        {
            Destroy(other.gameObject);
        }
    }
  
}
