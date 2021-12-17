﻿
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiTutorial : MonoBehaviour
{
//    public GameObject FR;
    public Health Hp;
    public float Distance;
    public int Damage;

    public NavMeshAgent agent;

    public Transform player;

    public Transform CoopAI;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public bool CoopAIInSightRange, CoopAIInAttackRange;
    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        CoopAI = GameObject.FindWithTag("CoopAI").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        CoopAIInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        CoopAIInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


        if (!playerInSightRange && !playerInAttackRange && !CoopAIInSightRange && !CoopAIInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (CoopAIInSightRange && !CoopAIInAttackRange) ChaseCoopAI();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        if (CoopAIInAttackRange && CoopAIInSightRange) AttackCoopAI();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void ChaseCoopAI()
    {
      agent.SetDestination(CoopAI.position);
    }


    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
//            FR.SetActive(true);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Distance))
            {
              if (hit.collider.GetComponent<Take>())
              {
                Hp.currentHealth -= Damage;
              }
          }
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void AttackCoopAI()
    {
      agent.SetDestination(transform.position);

      transform.LookAt(CoopAI);

      if (!alreadyAttacked)
      {
//            FR.SetActive(true);
          Ray ray = new Ray(transform.position, transform.forward);
          RaycastHit hit;
          if (Physics.Raycast(ray, out hit, Distance))
          {
            if (hit.collider.GetComponent<Coop>)
            {
              Hp.currentHealth -= Damage;
            }
        }
          alreadyAttacked = true;
          Invoke(nameof(ResetAttack), timeBetweenAttacks);
      }
    }
    private void ResetAttack()
    {
//        FR.SetActive(false);
        alreadyAttacked = false;
    }
}
