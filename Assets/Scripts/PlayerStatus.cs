using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider playerHealth;
    public float heartBeatTime;
    public bool hasPlay = false;
    public bool stamina;
    public Slider playerStamina;
    // Start is called before the first frame update
    void Start()
    {
        heartBeatTime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.value == 20 && !hasPlay)
        {
            heartBeatPlay();

            StartCoroutine(StopMusicAfterDelay(heartBeatTime));

            hasPlay= true;
        }

        if(playerHealth.value > 20)
        {
            hasPlay = false;
        }
    }

    IEnumerator StopMusicAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // ‘⁄—”≥Ÿ∫ÛÕ£÷π“Ù¿÷≤•∑≈
        audioSource.Stop();
    }

    void heartBeatPlay()
    {
        audioSource.Play();
        Debug.Log("Health is lower than 20!");
    }
}
