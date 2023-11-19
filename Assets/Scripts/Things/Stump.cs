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
        if (collision != null && collision.gameObject.CompareTag("Sword"))
        {
            // 造成伤害
            health -= 20;   
            Debug.Log("Suffer attack!");

            // 检查生命值是否小于等于0，如果是，则销毁物体
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
