using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int PointScore;
    [SerializeField] private GameUIController gameUIController;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<BulletScript>()!=null)
        {
            SoundManager.Instance.Play(SoundManager.Sounds.EnemyDeath);
            gameUIController.RefreshScoreUI(PointScore);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        else if(other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }

}
