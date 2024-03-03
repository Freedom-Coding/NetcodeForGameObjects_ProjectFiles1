using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(HealthSystem))]
public class Enemy : MonoBehaviour
{
    [SerializeField] float attackRange = 2;
    [SerializeField] int damage = 3;

    public EnemySpawner enemySpawner;
    private NavMeshAgent agent;
    private Transform player;


    void Start()
    {
        player = FindObjectOfType<Player>().transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void OnEnable()
    {
        GetComponent<HealthSystem>().OnDied += OnDied;
    }
    private void OnDisable()
    {
        GetComponent<HealthSystem>().OnDied -= OnDied;
    }

    private void OnDied()
    {
        enemySpawner.enemies.Remove(transform);
        Destroy(gameObject);
    }

    void Update()
    {
        Move();
    }

    private bool canAttack = true;
    private void Move()
    {
        if (Vector2.Distance(transform.position, player.position) > attackRange)
        {
            agent.destination = player.position;
        }
        else if (canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        canAttack = false;

        player.GetComponent<HealthSystem>().OnDamageDealt(damage);

        yield return new WaitForSeconds(2);
        canAttack = true;
    }
}