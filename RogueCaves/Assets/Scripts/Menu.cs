using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    [SerializeField]
    GameObject PauseWindow;
    [SerializeField]
    GameObject OptionsWindow;
    [SerializeField]
    GameObject MenuUI;
    [SerializeField]
    GameObject DeathUI;


    public int currentLevel;
    public bool isPaused=false;
    
    AudioManager audioManager;
    PlayerController player;
    

    enum MenuStates {Playing,Pause,Options,Dead }
    MenuStates currentState;

    void Update()
    {
        isPaused = PauseWindow.active;
       
        if (player.isDead)
        {
            currentState = MenuStates.Dead;
        }
        else if (Input.GetKeyDown("escape") && currentState == MenuStates.Playing)
        {
            currentState = MenuStates.Pause;
            isPaused = !isPaused;

        }
        else if (Input.GetKeyDown("escape") && currentState == MenuStates.Pause)
        {
            currentState = MenuStates.Playing;
            isPaused = !isPaused;
        }
        else if (currentState == MenuStates.Options)
        {
            isPaused = !isPaused;
        }
 


        switch (currentState)
        {
            case MenuStates.Playing:
                currentState = MenuStates.Playing;
                PauseWindow.SetActive(false);
                OptionsWindow.SetActive(false);
                MenuUI.SetActive(false);
       
                Time.timeScale = 1;

                break;
            case MenuStates.Pause:
                PauseWindow.SetActive(true);
                OptionsWindow.SetActive(false);
                MenuUI.SetActive(true);
                DeathUI.SetActive(false);
                Time.timeScale = 0;

                break;
            case MenuStates.Options:
                PauseWindow.SetActive(false);
                OptionsWindow.SetActive(true);
                MenuUI.SetActive(true);
                DeathUI.SetActive(false);
                Time.timeScale = 0;

                break;
            case MenuStates.Dead:
                PauseWindow.SetActive(false);
                OptionsWindow.SetActive(false);
                MenuUI.SetActive(false);
                DeathUI.SetActive(true);
                Time.timeScale = 1;

                break;

        }
    }

    void Start()    
    {
        player = FindObjectOfType<PlayerController>();
        currentState = MenuStates.Playing;
    
        audioManager = AudioManager.instance;
    }

  

    public void Restart()
    {
        SceneManager.LoadScene(currentLevel);
    }
    public void DisplayOptions()
    {
        currentState = MenuStates.Options;
    }
    public void Resume()
    {
        currentState = MenuStates.Playing;
    }
    public void Exit()
    {

        SceneManager.LoadScene(0);
    }
    public void BackButton()
    {
        currentState = MenuStates.Pause;
    }
    public void SetSFXVolume(float sfxLvl)
    {
        audioManager.SetFXVolume(sfxLvl);
    }
    public void SetMusicVolume(float musicLvl)
    {
        audioManager.SetMusicVolume(musicLvl);
    }
    public void SetMasterVolume(float masterLvl)
    {
        audioManager.SetMasterVolume(masterLvl);
    }
}

