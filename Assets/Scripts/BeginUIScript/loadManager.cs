using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadManager : MonoBehaviour
{
    public GameObject loadScene;
    public Slider loadSlider;
    public Text display;

    public void LoadScene()
    {
        StartCoroutine(LoadLevel());

    }

    public void LoadSceneContinue()
    {
        StartCoroutine(LoadLevelContinue());
    }

    IEnumerator LoadLevel()
    {
        loadScene.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");
        operation.allowSceneActivation = false;
        
        while(!operation.isDone)
        {
            loadSlider.value = operation.progress;

            display.text = operation.progress * 100 + " %";

            if (operation.progress >= 0.9f)
            {
                loadSlider.value = 1;

                display.text = "Press Any Key To Continue...";

                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }

    IEnumerator LoadLevelContinue()
    {
        saveSystem.LOAD = 1;

        loadScene.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            loadSlider.value = operation.progress;

            display.text = operation.progress * 100 + " %";

            if (operation.progress >= 0.9f)
            {
                loadSlider.value = 1;

                display.text = "Press Any Key To Continue...";

                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }

}