using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public GameObject decided;
    public TMP_Text volume;
    public Slider volumeBar;
    public int volumeValue = 50;
    public AudioSource heartBeat;
    private void Start()
    {
        volumeBar.value = volumeValue;
    }

    private void Update()
    {
        volume.text = volumeBar.value.ToString();
        heartBeat.volume = volumeBar.value/100;
    }
    public void BtnExitGame()
    {
        decided.SetActive(true);
    }

    public void Close()
    {
        decided.SetActive(false);
    }

    public void NoBtn()
    {
        decided.SetActive(false);
    }
    public void YesBtn()
    {
        Application.Quit();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
