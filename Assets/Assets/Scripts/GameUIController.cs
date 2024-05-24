using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private GameObject GameoverUI;
    [SerializeField] private GameObject GamewonUI;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Invaders;
    [SerializeField] private GameObject Mystyship;
    [SerializeField] private TextMeshProUGUI PointScoreUI;
    [SerializeField] private TextMeshProUGUI LifeScoreUI;
    [SerializeField] private int life;
    [SerializeField] private SpaceshipScript spaceshipScript;
    private int score=0;
    private bool Pause=false;
    private GameObject Enemy;
    [SerializeField] private PlayerController playerController;

    void Start()
     {
        RefreshScoreUI(0);
        RefreshLifeUI(0);
     }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Pause==false)
            {
                PauseGame();
                PauseUI.SetActive(true);
                Pause=true;
            }
            else
            {
                ResumeGame();
                PauseUI.SetActive(false);
                Pause=false;
            }
        }

            Enemy = GameObject.FindWithTag("Enemy");
            if(Enemy==null)
            {
                spaceshipScript.InvadersDeath();
                Debug.Log("ALl Invaders Death");

            }
    }

    public void QuitButton()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.onclick);
        Debug.Log("Application Quit");
        Application.Quit();
    }

    public void ResumeButton()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.onclick);
        PauseUI.SetActive(false);
        Pause=false;
        ResumeGame();
    }

    public void ReloadGame()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.onclick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LobbyLoading()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.onclick);
        SceneManager.LoadScene(0);
    }

    public void RefreshScoreUI(int sc)
    {
        score+=sc;

        PointScoreUI.text = "Score " + score;
    }

        public void RefreshLifeUI(int lifedecrease)
    {
        life=life-lifedecrease;
        if(life<1)
        {
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerDeath);
            PauseGame();
            playerController.PlayerExplosion();           
            Invoke("GameOverUI",2f);
            LifeScoreUI.text = "Life " + 0f;
        }
        else {
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerHit);

            LifeScoreUI.text = "Life " + life;
        }

    }

    public void GameOverUI()
    {
        GameoverUI.SetActive(true);
    }

        public void GameWonUI()
    {
        PauseGame();
        Invoke("GameWonUIActive",2f);


    }

    private void GameWonUIActive()
    {
        GamewonUI.SetActive(true);
    }


    public void PauseGame()
    {
        player.GetComponent<PlayerController>().enabled = false;
        Invaders.GetComponent<InvadersMove>().enabled = false;
        Mystyship.GetComponent<SpaceshipScript>().enabled = false;


    }

    public void ResumeGame()
    {
        player.GetComponent<PlayerController>().enabled = true;
        Invaders.GetComponent<InvadersMove>().enabled = true;
        Mystyship.GetComponent<SpaceshipScript>().enabled = true;

    }


}
