using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public abstract class EnemyAiTutorial : MonoBehaviour
{
    public float Distance;

    public int Damage = 5;
    public float DistanceToAttack;
    public float TimeReload = 3;
    protected bool canShot = true;

    public GameObject Weapon;

    private float visibilityDistance = 50;
    private float fieldOfViewDegrees = 360;
    public int queue;

    public LayerMask whatIsEnemy;

    public NavMeshAgent agent;
    //    public Animation anim;

    public Transform CoopAI, player,CurentTarget;
    public GameObject[] FindEnemys;
    public Transform[] Enemy;

    [SerializeField] protected bool IsFreand;

    private void Awake()
    {
        //        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("MainCamera").transform;
        //        StartCoroutine(CorotineAttack);
        if (IsFreand)
            fieldOfViewDegrees = 360;
        if (IsFreand)
        {
            FindEnemys = new GameObject[30];
            Enemy = new Transform[30];
        }
        else
        {
            FindEnemys = new GameObject[4];
            Enemy = new Transform[5];
        }
    }
    private void FixedUpdate()
    {
        WhoClosed();
        if (IsFreand)
        {
            Coop();
        }
        else
        {
            EnemyS(); 
        }
        if (CurentTarget != null)
            transform.LookAt(CurentTarget);
    }
    protected virtual void Attack()
    {
        if (Physics.Raycast(new Ray(Weapon.transform.position, Weapon.transform.forward), out RaycastHit hit, Distance))
        {
            hit.collider.gameObject.SendMessageUpwards("ChangeHealth", -Damage, SendMessageOptions.DontRequireReceiver);
            canShot = false;
        }
    }
    protected virtual void EnemyS()
    {
        Vector3 rayDirection = CurentTarget.transform.position - transform.position;
        if ((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfViewDegrees * 0.5f)
        {
            // Detect if player is within the field of view
            if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit, visibilityDistance))
            {
                if ((hit.transform.CompareTag("Player") || hit.transform.CompareTag("CoopAI")) && canShot)
                {
                    Attack();
                }
                else if((!hit.transform.CompareTag("Player") && !hit.transform.CompareTag("CoopAI")) && canShot)
                    Moving();
                else
                {
                    StartCoroutine(Reload(TimeReload));
                }
            }
        }
    }
    private void WhoClosed()
    {
        float x;
        int y = 0;
        if (!IsFreand)
        {
            FindEnemys = GameObject.FindGameObjectsWithTag("CoopAI");
            Enemy[0] = player;
            x = Vector3.Distance(Enemy[0].position, this.transform.position);
        }
        else
        {
            FindEnemys = GameObject.FindGameObjectsWithTag("Enemy");
            Enemy[0] = GameObject.FindWithTag("Enemy").transform;
            x = Vector3.Distance(Enemy[0].position, this.transform.position);
        }
        for (int i=0; i!= FindEnemys.Length; i++)
        {
            Enemy[i+1] = FindEnemys[i].transform;
        }

        for (int i=1;i!= FindEnemys.Length; i++)
        {
            if (x > Vector3.Distance(Enemy[i].position, this.transform.position)) 
            {
                x = Vector3.Distance(Enemy[i].position, this.transform.position);
                y = i;
            }
        CurentTarget = Enemy[y];

        }
    }
    private void Moving()
    {
        if (Vector3.Distance(CurentTarget.transform.position, this.transform.position) >= DistanceToAttack)
        {
            agent.destination = (CurentTarget.transform.position);
        }
        else
            agent.SetDestination(this.transform.position);
    }
    protected virtual void Coop()
    {
        Vector3 rayDirection = CurentTarget.transform.position - transform.position;
        if ((Vector3.Angle(transform.position, transform.forward * 50)) <= fieldOfViewDegrees * 0.5f)
        {
            if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit, visibilityDistance))
            {
                if (hit.transform.CompareTag("Enemy") && canShot)
                    Attack();
                else if (!hit.transform.CompareTag("Enemy") && canShot)
                    Moving();
                else
                    StartCoroutine(Reload(TimeReload));
            }
        }
    }
    IEnumerator Reload(float TimeReload)
    {
        yield return new WaitForSeconds(TimeReload);
        canShot = true;
        StopAllCoroutines();
    }
}
