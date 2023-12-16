using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public Slider staminaBar;
    public float maxHealth;
    public float maxStamina;
    public float health;
    public float damaged;
    public float stamina;
    public float lerpSpeed = 0.05f;
    public float staminaRecoverSpeed;
    public float staminaDepletionSpeed;
    public float sprintRecoverySpeed;
    public Text text_healthBar;
    public Text text_stamina;
    public bool isSprinting = false;
    public bool canSprint = true;

    //to get the current health
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        playerData playerData = player.GetComponent<playerData>();
        // judge whether the game is continue
        Debug.Log(saveSystem.LOAD);
        player = GameObject.FindGameObjectWithTag("Player");
        if (playerData.loadStatus == 1)
        {
            health = playerData.currentHealth;
            stamina = maxStamina;
            text_healthBar.text = $"{health} / 100";
            text_stamina.text = $"{maxStamina} / 100";

        }
        else if (saveSystem.LOAD == 0)
        {
            health = maxHealth;
            stamina = maxStamina;
            text_healthBar.text = $"{health} / 100";
            text_stamina.text = $"{maxStamina} / 100";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            takeDamage(damaged);
            Debug.Log("Take damage!");
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            heal();
        }

        if (healthSlider.value != health)
        {
            healthSlider.value = health;
            text_healthBar.text = $"{health} / 100";
        }

    
        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && stamina > 0.0f && canSprint)
        {
            isSprinting = true;
            stamina -= Time.deltaTime * staminaDepletionSpeed;
        }
        else
        {
            isSprinting = false;
        }

        if(stamina == 0)
        {
            canSprint = false;
        }

        if (stamina < 30.0f && !isSprinting)
        {
            canSprint= false;
        }
        else
        {
            canSprint = true;
        }

        if (isSprinting)
        {
            stamina += sprintRecoverySpeed * Time.deltaTime;
        }
        else
        {
            stamina += staminaRecoverSpeed * Time.deltaTime;
        }

        stamina = Mathf.Clamp(stamina, 0f, 100f);
        health = Mathf.Clamp(health, 0f, 100f);
        if (staminaBar.value != stamina)
        {
            staminaBar.value = stamina;
            text_stamina.text = $"{stamina} / 100";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage"></param>
    void takeDamage(float damage)
    {
        health -= damage;
    }

    void heal()
    {
        health += 10;
    }

    IEnumerator setHealthPoints(float healthLoad)
    {
        yield return new WaitForSeconds(5f);

        health = healthLoad;
    }
}
