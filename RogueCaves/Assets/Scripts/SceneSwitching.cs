using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour
{
    public int ValueTxt;

    void Start()
    {
        ValueTxt = PresistentManager.Instance.Value;
    }
    public void GoToFirstScene()
    {
        PresistentManager.Instance.Value++;
    }
}
