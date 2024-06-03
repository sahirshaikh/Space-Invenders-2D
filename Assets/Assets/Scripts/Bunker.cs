using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bunker : MonoBehaviour
{

    [SerializeField] private int bunkerScore;
    [SerializeField] private TextMeshPro scoreUI;
    [SerializeField] private int playerEnemyBulletHit;
    [SerializeField] private int torpedoHit;

    void Start()
    {
        BunkerAttack(0);      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.GetComponent<PlayerBullet>() != null)||(collision.GetComponent<EnemyBullet>()!=null))
        {
            Destroy(collision.gameObject);
            BunkerAttack(playerEnemyBulletHit);
        }
        else if(collision.GetComponent<Torpedo>()!=null)
        {
            BunkerAttack(torpedoHit);
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
