using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletPos;
    [SerializeField] private GameObject explosion;
    [SerializeField]private GameUIController gameUIController;
    [SerializeField] private int torpedoHit;
    [SerializeField] private int enemyBulletHit;
    private void Update()
    {
        PlayerMovement();

        if(Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerShoot);
            BulletFire();
        }

    }
    private void PlayerMovement()
    {
        var dir = new Vector2(Input.GetAxis("Horizontal"),0);
        transform.Translate(dir*speed*Time.deltaTime);
    }

    private void BulletFire()
    {
        Vector2 bulletSpawnPos = bulletPos.transform.position;
        Instantiate(bullet,bulletSpawnPos,Quaternion.identity);
    }

        private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<Torpedo>()!=null)
        {
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerHit);
            gameUIController.RefreshLifeUI(torpedoHit);
            Destroy(other.gameObject);
        }

        else if(other.gameObject.GetComponent<EnemyBullet>()!=null)
        {
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerHit);
            gameUIController.RefreshLifeUI(enemyBulletHit);
            Destroy(other.gameObject);
        }
    }

    public void PlayerExplosion()
    {
        Vector2 explosionPos = this.transform.position;
        Instantiate(explosion,explosionPos,Quaternion.identity);    
    }

}
