using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceshipScript : MonoBehaviour
{
    [SerializeField] private float spaceshipSpeed;
    private float dir=1;
    [SerializeField] private GameObject torpedo;
    [SerializeField] private GameObject torpedoPos;
    [SerializeField] private int mystryshipScore;
    [SerializeField] private TextMeshPro scoreUI;
    [SerializeField] private GameUIController finalScoreUI;
    [SerializeField] private float instantiationTimer;
    [SerializeField] private GameObject explosion;
    private float fixedTimer;
    private bool invadersDeath= false;
    
    void Start()
    {
        SpaceshipScore(0);
        fixedTimer=instantiationTimer;
    }
    void Update()
    {
        transform.Translate(dir * spaceshipSpeed * Time.deltaTime,0,0);
        CreateTorpedo();
    }

    private void CreateTorpedo()
    {
        instantiationTimer -= Time.deltaTime;
	    if (instantiationTimer <= 0)
	    {
            Vector2 torPos= torpedoPos.transform.position;
            Instantiate(torpedo, torPos, Quaternion.identity);
		    instantiationTimer = fixedTimer;
	    }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.GetComponent<BoundryScript>()!=null)
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
                SpaceshipScore(1);
                finalScoreUI.RefreshScoreUI(20);
                Destroy(other.gameObject);
            }
           
        }
        
    }

    public void SpaceshipScore(int value)
    {
        mystryshipScore -=value;
        if (mystryshipScore <= 0)
        {
            Vector2 explosionPos = this.transform.position;
            Instantiate(explosion,explosionPos, Quaternion.identity);
            finalScoreUI.GameWonUI();
            Invoke("DestroyMystryship",2f);
            mystryshipScore=0;
        }
        RefreshUI();
    }

    public void RefreshUI()
    {
        scoreUI.text = mystryshipScore+"";
    }

    public void DestroyMystryship()
    {
        Destroy(gameObject);
    }

}
