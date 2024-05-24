using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceshipScript : MonoBehaviour
{
    [SerializeField] private float SpaceshipSpeed;
    private float dir=1;
    [SerializeField] private GameObject torpedo;
    [SerializeField] private GameObject torpedoPos;
    [SerializeField] private int MystryshipScore;
    [SerializeField] private TextMeshPro ScoreUI;
    [SerializeField] private GameUIController FinalScoreUI;
    [SerializeField] private float InstantiationTimer;
    [SerializeField] private GameObject explosion;

    private float FixedTimer;
    private bool invadersDeath= false;
    
    void Start()
    {
        RefreshUI(0);
        FixedTimer=InstantiationTimer;
    }

    void Update()
    {
        transform.Translate(dir * SpaceshipSpeed * Time.deltaTime,0,0);
        CreateTorpedo();

    }

    private void CreateTorpedo()
    {
        InstantiationTimer -= Time.deltaTime;
	    if (InstantiationTimer <= 0)
	{
        Vector2 torPos= torpedoPos.transform.position;
        Instantiate(torpedo, torPos, Quaternion.identity);
		InstantiationTimer = FixedTimer;
	}

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Boundary"))
        {
            dir=-dir;
        }
        
    }

    public void InvadersDeath()
    {
        invadersDeath=true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<BulletScript>()!=null)
        {
            if(invadersDeath==true)
            {
                SoundManager.Instance.Play(SoundManager.Sounds.EnemyDeath);
                RefreshUI(1);
                FinalScoreUI.RefreshScoreUI(20);
                Destroy(other.gameObject);

            }
           
        }
        
    }

    public void RefreshUI(int BC)
    {
        MystryshipScore -=BC;

        ScoreUI.text = MystryshipScore+"";
        if (MystryshipScore <= 0)
        {
            Vector2 explosionPos = this.transform.position;
            Instantiate(explosion,explosionPos, Quaternion.identity);
            FinalScoreUI.GameWonUI();
            Invoke("DestroyMystryship",2f);

        }
    }

    public void DestroyMystryship()
    {
        Destroy(gameObject);
    }

}
