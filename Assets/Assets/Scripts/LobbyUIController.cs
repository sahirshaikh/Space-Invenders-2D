using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LobbyUIController : MonoBehaviour
{

    [SerializeField] private GameObject StartUI;
    [SerializeField] private string LevelName;


    public void PlayButton()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.onclick);
        Debug.Log("Game Started");
        SceneManager.LoadScene(LevelName);
    }
    

    public void QuitButton()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.onclick);
        Debug.Log("Application Quit");
        Application.Quit();
    }







}
