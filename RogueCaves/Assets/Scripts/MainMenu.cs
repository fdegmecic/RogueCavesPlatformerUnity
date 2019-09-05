using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    AudioManager audiomanager;
    
    public static MainMenu instance;

    private void Start()
    {
        audiomanager = AudioManager.instance;
        audiomanager.playSound("MenuSong");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayStory()
    {
        if (PresistentManager.Instance.Value == 0) {
            
        SceneManager.LoadScene(4);
        
        }
        else if (PresistentManager.Instance.Value >= 0)
        {
            SceneManager.LoadScene(1);
        }
    } 
    public void loadLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void loadLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void loadLevel4()
    {
        SceneManager.LoadScene(5);
    }
    public void loadLevel5()
    {
        SceneManager.LoadScene(6);
    }


    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    void Awake()
    {
        instance = this;
    }
    
}
