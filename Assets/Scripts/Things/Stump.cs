using UnityEngine;

public class Stump : MonoBehaviour
{
    public float health = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Generated!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.CompareTag("GemSword"))
        {
            // ‘Ï≥……À∫¶
            health -= 20;   
            Debug.Log("Suffer attack!");

            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            // check whether its health is lower than 0, if so destroy gameobject
            if (health <= 0)
            {
                Destroy(gameObject,1);
            }
        }
    }
}
