
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAiTutorial : MonoBehaviour
{
//    public GameObject FR;
    public float Distance,visibl;
    public int Damage;

    public GameObject Weapon;

    public float visibilityDistance;
    public float fieldOfViewDegrees;

    public NavMeshAgent agent;
//    public Animation anim;

    public Transform CoopAI,Enemy,player,FollowPL;

    public bool isFreandly = false;
    //Ai search
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
    public bool FalletSteals = false;
//    public Alarm Alarmed;
    public GameObject Alarmed;
    public bool alarmedSignal = false;
    public float timeToAllarm = 5f;

    private void Awake()
    {
//        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
      Alarmed = GameObject.FindWithTag("Dirt");
      alarmedSignal = Alarmed.GetComponent<Alarm>().alarm;
        if (alarmedSignal == true)
        {
          FalletSteals = true;
        }
      if (FalletSteals == false)
      {
      CanSeePlayer();
      }
      else{
      if (isFreandly == false)
        {
          EnemyS();
        }
      else //(isFreandly == true)
        {
          FreandS();
        }
      }
    }

    private void EnemyS()
    {
      player = GameObject.FindWithTag("Player").transform;
      playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
      playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

      if (!playerInSightRange && !playerInAttackRange && !CoopAIInSightRange && !CoopAIInAttackRange) Patroling();
      if (playerInSightRange && !playerInAttackRange) ChasePlayer();
      if (playerInAttackRange && playerInSightRange) AttackPlayer();
      CoopAI = GameObject.FindWithTag("CoopAI").transform;
      CoopAIInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsCoop);
      CoopAIInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsCoop);

      if (CoopAIInSightRange && !CoopAIInAttackRange) ChaseCoopAI();
      if (CoopAIInAttackRange && CoopAIInSightRange) AttackCoopAI();
    }

    private void FreandS()
    {
      gameObject.tag = "CoopAI";
      gameObject.layer = 19;
      player = GameObject.FindWithTag("Player").transform;
      Enemy = GameObject.FindWithTag("Enemy").transform;
      EnemyInsightRange = Physics.CheckSphere(transform.position, sightRange, whatIsEnemy);
      EnemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);
      if (!EnemyInsightRange && !EnemyInAttackRange) FolloPlayer();
      if (EnemyInsightRange && !EnemyInAttackRange) ChaseEnemy();
      if (EnemyInAttackRange && EnemyInsightRange) AttackEnemy();
      Enemy = GameObject.FindWithTag("Enemy").transform;
    }

    private void FolloPlayer(){
      FollowPL = GameObject.FindWithTag("Follow").transform;
      agent.SetDestination(FollowPL.position);
//      anim.Play("Move");
    }

    private void Patroling(){
        if (!walkPointSet) SearchWalkPoint();
//        anim.Play("IdleSht");

        if (walkPointSet)
            agent.SetDestination(walkPoint);
//            anim.Play("Move");

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
    private void ChasePlayer(){
        agent.SetDestination(player.position);
    }
    private void ChaseCoopAI(){
      agent.SetDestination(CoopAI.position);
    }
    private void ChaseEnemy(){
      agent.SetDestination(Enemy.position);
    }

    private void AttackPlayer(){
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
//            FR.SetActive(true);
            Ray ray = new Ray(Weapon.transform.position, Weapon.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Distance))
            {
              Debug.DrawLine(transform.position,transform.forward);
              if (hit.collider.GetComponent<Take>())
              {
                for (int i=0; i<3;i++)
                {
                hit.collider.gameObject.SendMessageUpwards("ChangeHealth", -Damage, SendMessageOptions.DontRequireReceiver);
                waiter();
                }
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
          Ray ray = new Ray(Weapon.transform.position, Weapon.transform.forward);
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
          Ray ray = new Ray(Weapon.transform.position, Weapon.transform.forward);
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
    protected bool CanSeePlayer()
    {
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - transform.position;

        if ((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfViewDegrees * 0.5f)
        {
            // Detect if player is within the field of view
            if (Physics.Raycast(transform.position, rayDirection, out hit, visibilityDistance))
            {
                if (hit.transform.CompareTag("Player"));
                {
                  visibl+=25 * Time.deltaTime;
                  if (visibl >= 100)
                  {
                    FalletSteals = true;
                    CallAllarm();
                  }
                }
            }
        }
        return false;
      }

    public void CallAllarm()
    {
      Alarmed.GetComponent<Alarm>().alarm = true;
    }

    IEnumerator waiter()
    {
      yield return new WaitForSeconds(2);
    }




}
