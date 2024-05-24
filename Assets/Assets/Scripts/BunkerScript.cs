using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BunkerScript : MonoBehaviour
{

    [SerializeField] private int bunkerScore;
    // [SerializeField] private TextMeshProUGUI ScoreUI;
    [SerializeField] private TextMeshPro ScoreUI;

    void Start()
    {
        RefreshUI(0);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<BulletScript>() != null)
        {
            Destroy(collision.gameObject);

            RefreshUI(1);
            Debug.Log("Impact");

        }

        else if(collision.GetComponent<TorpedoScript>()!=null)
        {
            RefreshUI(2);
            Destroy(collision.gameObject);

        }
        else if(collision.GetComponent<EnemyBullets>()!=null)
        {
            RefreshUI(1);
            Destroy(collision.gameObject);

        }
        
    }

    public void RefreshUI(int BC)
    {
        bunkerScore -=BC;

        ScoreUI.text = bunkerScore+"";
        if (bunkerScore <= 0)
        {
            Destroybunker();
        }
    }

    public void Destroybunker()
    {
        Destroy(gameObject);
    }

}
