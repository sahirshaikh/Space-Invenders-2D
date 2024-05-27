using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameWonUI;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject invaders;
    [SerializeField] private GameObject mystyship;
    [SerializeField] private TextMeshProUGUI pointScoreUI;
    [SerializeField] private TextMeshProUGUI lifeScoreUI;
    [SerializeField] private GameObject spaceShipText;
    [SerializeField] private int life;
    [SerializeField] private SpaceshipScript spaceshipScript;
    private int score=0;
    private bool pause=false;
    private GameObject enemy;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private List<GameObject> invadersList = new List<GameObject>();

    void Start()
     {
        RefreshScoreUI(0);
        RefreshLifeUI(0);
     }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pause==false)
            {
                PauseGame();
                pauseUI.SetActive(true);
                pause=true;
            }
            else
            {
                ResumeGame();
                pauseUI.SetActive(false);
                pause=false;
            }
        }

        invadersList.RemoveAll(s => s == null);
        if(invadersList.Count==0)
        {
                spaceshipScript.InvadersDeath();
                spaceShipText.SetActive(true);
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
        pauseUI.SetActive(false);
        pause=false;
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
        RefreshScoreUIScore(score);
    }

    public void RefreshScoreUIScore(int score)
    {
        pointScoreUI.text = "Score " + score;
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
            RefreshLifeUIScore(0);
        }
        else {
            RefreshLifeUIScore(life);
        }
    }

    public void RefreshLifeUIScore(int score)
    {
        lifeScoreUI.text = "Life " + life;
    }

    public void GameOverUI()
    {
        gameOverUI.SetActive(true);
    }
        public void GameWonUI()
    {
        PauseGame();
        Invoke("GameWonUIActive",2f);
    }

    private void GameWonUIActive()
    {
        gameWonUI.SetActive(true);
    }
    public void PauseGame()
    {
        player.GetComponent<PlayerController>().enabled = false;
        invaders.GetComponent<InvadersMove>().enabled = false;
        mystyship.GetComponent<SpaceshipScript>().enabled = false;
    }

    public void ResumeGame()
    {
        player.GetComponent<PlayerController>().enabled = true;
        invaders.GetComponent<InvadersMove>().enabled = true;
        mystyship.GetComponent<SpaceshipScript>().enabled = true;
    }
}
