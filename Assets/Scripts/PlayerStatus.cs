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
    private Animator animator;
    public AudioClip clipHeartBeat;
    public AudioClip clipWeapon;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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

        if(playerHealth.value == 0)
        {
            animator.SetBool("Dying", true);
        }
        
        if(playerHealth.value > 0)
        {
            animator.SetBool("Dying", false);
        }

        if(playerHealth.value > 20)
        {
            hasPlay = false;
        }

        if(Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Axe",true);
            weaponPlay();
            StartCoroutine(weaponMusicPlay());
            Debug.Log("Mouse 1 is pressed.");
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("Axe"))
        {
            animator.SetBool("Axe", false);
        }
    }

    IEnumerator weaponMusicPlay()
    {
        yield return new WaitForSeconds(1);
        audioSource.Stop();
    }

    IEnumerator StopMusicAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // ‘⁄—”≥Ÿ∫ÛÕ£÷π“Ù¿÷≤•∑≈
        audioSource.Stop();
    }

    void weaponPlay()
    {
        audioSource.clip = clipWeapon;
        audioSource.Play();
    }

    void heartBeatPlay()
    {
        audioSource.clip = clipHeartBeat;
        audioSource.Play();
    }
}
