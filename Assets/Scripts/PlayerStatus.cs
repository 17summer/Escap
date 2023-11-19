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

    //public float coolDownTime = 2.0f;
    //private float nextFireTime = 0.0f;
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
            Debug.Log("Mouse 1 is pressed.");
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("Axe"))
        {
            animator.SetBool("Axe", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Appear!");
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
