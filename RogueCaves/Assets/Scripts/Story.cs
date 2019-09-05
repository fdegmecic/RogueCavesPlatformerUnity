using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public string loadLevel;
    public Text splashImage;
    AudioManager audiomanager;

   

    IEnumerator Start()
    {


        splashImage.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine("FadeIn");
        yield return new WaitForSeconds(5f);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("FadeOut");
            FadeOut1();

        }
    }


    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 4f, false);
    }
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2.5f);
        FadeOut1();
        SceneManager.LoadScene(loadLevel);
    }
    void FadeOut1()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }

}