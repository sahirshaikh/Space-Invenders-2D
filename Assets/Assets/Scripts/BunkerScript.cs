using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BunkerScript : MonoBehaviour
{

    [SerializeField] private int bunkerScore;
    [SerializeField] private TextMeshPro scoreUI;

    void Start()
    {
        BunkerAttack(0);      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.GetComponent<BulletScript>() != null)||(collision.GetComponent<EnemyBullets>()!=null))
        {
            Destroy(collision.gameObject);
            BunkerAttack(1);
        }
        else if(collision.GetComponent<TorpedoScript>()!=null)
        {
            BunkerAttack(2);
            Destroy(collision.gameObject);
        }
        
    }
    public void BunkerAttack(int value)
    {
        if (bunkerScore > 0)
        {
            bunkerScore -=value;

            if(bunkerScore<=0)
                {
                    bunkerScore=0;
                    DestroyBunker();
                }
            RefreshUI();
        }
    }

    public void RefreshUI()
    {
        scoreUI.text = bunkerScore+"";
    }
    public void DestroyBunker()
    {
        Destroy(gameObject);
    }

}
