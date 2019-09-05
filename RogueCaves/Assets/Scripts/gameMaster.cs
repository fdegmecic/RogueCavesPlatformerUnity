using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameMaster : MonoBehaviour {



    [SerializeField]
    GameObject[] switches;
    [SerializeField]
    GameObject exitDoor;
    [SerializeField]
    Text switchCount;
    int noOfSwitches = 0;

    public void LoadNextLevel(int x)
    {
        SceneManager.LoadScene(x);
    }

    void Start()
    {
        GetNoOfSwitches();
    }
    public int GetNoOfSwitches()
    {
        int x = 0;
        for(int i = 0; i < switches.Length; i++)
        {   
            if (switches[i].GetComponent<Switch>().isOn == false)
                x++;
            else if (switches[i].GetComponent<Switch>().isOn == true)
                noOfSwitches--;
        }
        noOfSwitches = x;

        return noOfSwitches;
    }

    public void GetExiteDoorState()
    {
      if (noOfSwitches <= 0)
        {
            exitDoor.GetComponent<Door>().OpenDoor();
        }
    }

    void Update()
    {
        switchCount.text = GetNoOfSwitches().ToString();
        GetExiteDoorState();
    }
}
