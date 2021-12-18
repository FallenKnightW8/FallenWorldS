
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiTutorial : MonoBehaviour
{
//    public GameObject FR;
    public float Distance;
    public int Damage;

    public NavMeshAgent agent;

    public Transform player;

    public Transform CoopAI,Enemy;

    public bool isFreandly = false;

    public LayerMask whatIsGround, whatIsPlayer, whatIsCoop,whatIsEnemy;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange,EnemyInsightRange;
    public bool CoopAIInSightRange, CoopAIInAttackRange,EnemyInAttackRange;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        if (isFreandly == false)
        {
        player = GameObject.Find("PlayerObj").transform;
        CoopAI = GameObject.FindWithTag("CoopAI").transform;
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        CoopAIInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsCoop);
        CoopAIInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsCoop);


        if (!playerInSightRange && !playerInAttackRange && !CoopAIInSightRange && !CoopAIInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        if (CoopAIInSightRange && !CoopAIInAttackRange) ChaseCoopAI();
        if (CoopAIInAttackRange && CoopAIInSightRange) AttackCoopAI();
      }
      if (isFreandly == true)
      {
        gameObject.tag = "CoopAI";
        gameObject.layer = 19;
        player = GameObject.Find("PlayerObj").transform;
        Enemy = GameObject.FindWithTag("Enemy").transform;
        EnemyInsightRange = Physics.CheckSphere(transform.position, sightRange, whatIsEnemy);
        EnemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);
        if (!EnemyInsightRange && !EnemyInAttackRange) FolloPlayer();
        if (EnemyInsightRange && !EnemyInAttackRange) ChaseEnemy();
        if (EnemyInAttackRange && EnemyInsightRange) AttackEnemy();
      }
    }

    private void FolloPlayer()
    {
      agent.SetDestination(player.position*2);
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
    private void ChaseEnemy()
    {
      agent.SetDestination(Enemy.position);
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
              Debug.DrawLine(transform.position,transform.forward);
              if (hit.collider.GetComponent<Take>())
              {
                hit.collider.gameObject.SendMessageUpwards("ChangeHealth", -Damage, SendMessageOptions.DontRequireReceiver);
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
            if ((hit.collider.GetComponent<EnemyAiTutorial>()) ^ (hit.collider.GetComponent<Coop>()))
            {
              hit.collider.gameObject.SendMessageUpwards("ChangeHealth", -Damage, SendMessageOptions.DontRequireReceiver);
            }
        }
          alreadyAttacked = true;
          Invoke(nameof(ResetAttack), timeBetweenAttacks);
      }
    }
    private void AttackEnemy()
    {
      agent.SetDestination(transform.position);

      transform.LookAt(Enemy);

      if (!alreadyAttacked)
      {
//            FR.SetActive(true);
          Ray ray = new Ray(transform.position, transform.forward);
          RaycastHit hit;
          if (Physics.Raycast(ray, out hit, Distance))
          {
            if (hit.collider.GetComponent<EnemyAiTutorial>())
            {
              hit.collider.gameObject.SendMessageUpwards("ChangeHealth", -Damage, SendMessageOptions.DontRequireReceiver);
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
