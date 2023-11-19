using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continues : MonoBehaviour
{
    public GameObject panel;
    public void playerPrefsContinue()
    {
        panel.SetActive(true);
    }

    public void Back()
    {
        panel.SetActive(false); 
    }


    public void gameQuit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
