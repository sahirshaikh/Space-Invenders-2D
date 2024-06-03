using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int pointScore;
    [SerializeField] private GameUIController gameUIController;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerBullet>()!=null)
        {
            SoundManager.Instance.Play(SoundManager.Sounds.EnemyDeath);
            gameUIController.RefreshScoreUI(pointScore);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
