using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth;
    public float health;
    public float damaged;
    public float lerpSpeed = 0.05f;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        text.text = $"{health} / 100";
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
            text.text = $"{health} / 100";
        }

    
        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }
    }

    void takeDamage(float damage)
    {
        health -= damage;
    }

    void heal()
    {
        health += 10;
    }
}
