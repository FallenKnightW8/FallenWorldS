using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public abstract class EnemyAiTutorial : MonoBehaviour
{  
    public float Distance;

    public int Damage = 5;

    public float TimeReload = 3;
    protected bool canShot = true;

    public GameObject Weapon;

    private float visibilityDistance = 50;
    private float fieldOfViewDegrees = 360;
    public int queue;

    public LayerMask whatIsEnemy;

    public NavMeshAgent agent;
//    public Animation anim;

    public Transform CoopAI,Enemy,player;

    [SerializeField] protected bool IsFreand;

    private void Awake()
    {
//        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("MainCamera").transform;
//        StartCoroutine(CorotineAttack);
        if(IsFreand)
        fieldOfViewDegrees = 360;
}
    private void FixedUpdate()
    {
        if (IsFreand)
        {
            Enemy = GameObject.FindWithTag("Enemy").transform;
            Coop();
        }
        else EnemyS();
        if (Enemy != null)
            transform.LookAt(Enemy);
    }

    protected virtual void AttacPlayer()
    { 
        Ray ray = new Ray(Weapon.transform.position, Weapon.transform.forward);
        RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Distance))
            {
            hit.collider.gameObject.SendMessageUpwards("ChangeHealth", -Damage, SendMessageOptions.DontRequireReceiver);
            canShot = false;
            }
            else
            agent.SetDestination(Enemy.position);
    }
    protected virtual void EnemyS()
    {
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - transform.position;
        if ((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfViewDegrees * 0.5f)
        {
            // Detect if player is within the field of view
            if (Physics.Raycast(transform.position, rayDirection, out hit, visibilityDistance))
            {
                if ((hit.transform.CompareTag("Player") || hit.transform.CompareTag("CoopAI")) && canShot) 
                {
                    if (hit.transform.CompareTag("CoopAI"))
                    {
                        CoopAI = hit.transform;
                        Enemy = CoopAI;
                    }
                    else
                    {
                        Enemy = player;
                    }
                    AttacPlayer();
                }
                else
                {
                    StartCoroutine(Reload(TimeReload));
                }
            }
        }
    }

    protected virtual void Coop()
    {
        RaycastHit hit;
        Vector3 rayDirection = Enemy.transform.position - transform.position;
        if ((Vector3.Angle(transform.position, transform.forward*50)) <= fieldOfViewDegrees * 0.5f)
        {
            if (Physics.Raycast(transform.position, rayDirection, out hit, visibilityDistance))
            {
                if (hit.transform.CompareTag("Enemy") && canShot)
                {
                    if (hit.transform.CompareTag("Enemy")) Enemy = hit.transform;
                    AttacPlayer();
                }
                else if(!hit.transform.CompareTag("Enemy") && canShot)
                {
                    agent.SetDestination(Enemy.position);
                }
                else
                {
                    StartCoroutine(Reload(TimeReload));
                }
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
