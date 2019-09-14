
using UnityEngine;
using UnityEngine.SceneManagement;
public class Changer : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    public int levelIndex;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FadeToLevel(levelIndex);

        }

    }
    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void OnFadeStart()
    {
        animator.SetTrigger("FadeIn");
    }
}
