using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public HealthBar healthBar;

    private bool flag;

    public GameObject player;
    private PlayerController playerController;
    private RAYCastPickup rAYCastPickup;
    private PlayerStatus playerStatus;

    public Button restart;
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        healthBar = FindObjectOfType<HealthBar>();
        animator = GetComponent<Animator>();
        heartBeatTime = 5.0f;

        playerController = player.GetComponent<PlayerController>();
        rAYCastPickup = player.GetComponent<RAYCastPickup>();
        playerStatus = player.GetComponent<PlayerStatus>();

        if(restart != null)
        {
            restart.gameObject.SetActive(false);    
        }
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

            playerController.enabled = false;
            rAYCastPickup.enabled = false;
            playerStatus.enabled = false;
            restart.gameObject.SetActive(true);
        }

        if (playerHealth.value > 0)
        {
            animator.SetBool("Dying", false);
        }

        if(playerHealth.value > 20)
        {
            hasPlay = false;
        }

        // sword music effect and wave animation
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Axe",true);
            if(flag)
            {
                StartCoroutine(weaponWaitMusicPlay());
                weaponPlay(flag);
                StartCoroutine(weaponMusicPlay());

            }
            Debug.Log("Mouse 1 is pressed.");
            flag = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("Axe"))
        {
            flag = true;
            animator.SetBool("Axe", false);
        }
    }
    IEnumerator weaponWaitMusicPlay()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator weaponMusicPlay()
    {
        yield return new WaitForSeconds(1);
        audioSource.Stop();
    }

    IEnumerator StopMusicAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // ���ӳٺ�ֹͣ���ֲ���
        audioSource.Stop();
    }

    void weaponPlay(bool flag)
    {
        if(flag)
        {
            audioSource.clip = clipWeapon;
            audioSource.Play();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Bullet")
        {
            Debug.Log("Hit by bullet");
            healthBar.takeDamage(5);
        }
    }
    void heartBeatPlay()
    {
        audioSource.clip = clipHeartBeat;
        audioSource.Play();
    }

}
