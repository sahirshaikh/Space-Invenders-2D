using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LobbyUIController : MonoBehaviour
{

    [SerializeField] private GameObject startUI;
    [SerializeField] private string levelName;
    public void PlayButton()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.onclick);
        Debug.Log("Game Started");
        SceneManager.LoadScene(levelName);
    }
    public void QuitButton()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.onclick);
        Debug.Log("Application Quit");
        Application.Quit();
    }







}
