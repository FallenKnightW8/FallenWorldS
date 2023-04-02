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
    private float fieldOfViewDegrees = 180;
    public int queue;

    public NavMeshAgent agent;
//    public Animation anim;

    public Transform CoopAI,Enemy,player;

    private void Awake()
    {
//        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("MainCamera").transform;
//        StartCoroutine(CorotineAttack);
    }
    private void FixedUpdate()
    {
        EnemyS();
        if (Enemy != null)
            transform.LookAt(Enemy);
        else
            Enemy = player;
    }

    //    IEnumerator AttackPlayer(float timeToShot)
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
                    //                    StartCoroutine(AttackPlayer(timeToShot));
//                    Debug.Log("attack");
                    if (hit.transform.CompareTag("Player")) Enemy = player;
                    else
                    {
                        CoopAI = hit.transform;
                        Enemy = CoopAI;
                    }
                    AttacPlayer();
                }
                else
                {
//                    Debug.Log("reload");
                    StartCoroutine(Reload(TimeReload));
                }
//else if (hit.transform.CompareTag(""))
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
