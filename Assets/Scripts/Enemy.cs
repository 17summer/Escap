using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public float patrolSpeed = 3f;
    public float patrolWaitTime = 0.5f;
    public Transform patrolWayPoints;

    private NavMeshAgent agent;
    private float patorlTimer = 0f;
    private int wayPointIndex = 0;

    public float chaseSpeed = 6f;
    public float chaseWaitTime = 5f;
    private float chaseTimer = 0f;
    public float sqrPlayerDist = 4f;
    private bool chase = false;

    public float shootRotSpeed = 4f;
    public float shootFreeTime = 2f;
    private float shootTimer = 0f;

    private EnemySight enemySight;
    private Transform player;

    public float maxHealth = 100f;
    private float health;
    
    private Animator animator;
    private AudioSource audioSource;
    public Rigidbody bullet;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemySight = transform.Find("EnemySight").GetComponent<EnemySight>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
        animator = GetComponent<Animator>();
        
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(enemySight.playerInSight) 
        {
            Shooting();
            chase = true;
            animator.SetBool("Walking", false);
            animator.SetBool("Running", false);
            animator.SetBool("Attack", true);
        }
        else if(chase)
        {
            Chasing();
            animator.SetBool("Walking", false);
            animator.SetBool("Running", true);
            animator.SetBool("Attack", false);
        }
        else
        {
            Patrolling();
            animator.SetBool("Walking", true);
            animator.SetBool("Running", false);
            animator.SetBool("Attack", false);
        }
        
    }
    void Shooting()
    {
        Vector3 lookPos = player.position;
        lookPos.y = transform.position.y;

        Vector3 targetDir = lookPos - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDir), Mathf.Min(1f, Time.deltaTime * shootRotSpeed));
        agent.isStopped = true;
        if(Vector3.Angle(transform.forward, targetDir) < 2)
        {
            if(shootTimer > shootFreeTime)
            {
                audioSource.Play();
                Instantiate(bullet, transform.position, Quaternion.LookRotation(player.position - transform.position));
                shootTimer = 0f;
            }
            shootTimer += Time.deltaTime;
        }
    }
    void Chasing()
    {
        agent.isStopped = false;
        Vector3 sightDeltPos = enemySight.playerLastSight - transform.position;
        if (sightDeltPos.sqrMagnitude > sqrPlayerDist)
            agent.destination = enemySight.playerLastSight;
        agent.speed = chaseSpeed;
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            chaseTimer += Time.deltaTime;
            if (chaseTimer > chaseWaitTime)
            {
                chase = false;
                chaseTimer = 0f;
            }
        }
        else
            chaseTimer = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.tag == "Sword" || other.gameObject.tag == "GemSword" || other.gameObject.tag == "Axe")
        {
            float damage = CalculateDamage(other.gameObject.tag);
            TakeDamage(damage);
        }
    }

    private float CalculateDamage(string weaponTag)
    {
        switch (weaponTag)
        {
            case "Sword":
                return 10f;  // 剑造成的伤害
            case "GemSword":
                return 20f;  // 宝石剑造成的伤害
            case "Axe":
                return 15f;  // 斧头造成的伤害
            default:
                return 0f;
        }
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);

        if (health <= 0)
        {
            // 敌人死亡的逻辑处理
            Destroy(gameObject);
        }
    }


void Patrolling()
    {
        agent.isStopped = false;
        agent.speed = patrolSpeed;
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            patorlTimer += Time.deltaTime;
            if (patorlTimer > patrolWaitTime)
            {
                if (wayPointIndex == patrolWayPoints.childCount - 1)
                    wayPointIndex = 0;
                else
                    wayPointIndex++;
                patorlTimer = 0;
            }
        }
        else
            patorlTimer = 0;
        agent.destination = patrolWayPoints.GetChild(wayPointIndex).position;
    }
}
