using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour
{
    [SerializeField]private float torpedoSpeed;
    private int dir =-1;

    void Update()
    {
        transform.Translate( 0, dir * torpedoSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
            Debug.Log("Torpedo");
        }
    }


}
