using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class EnemyAiTutorial : MonoBehaviour
{   //^^^abstract
//    public GameObject FR;
    public float Distance,visibl;

    public int Damage;

    private float Reloadtime;
    private IEnumerator CorotineAttack;
    public float MyTime = 3;
    public float timeRound;
    [SerializeField]private float timeToShot = 2f;

    public GameObject Weapon;

    public float visibilityDistance;
    public float fieldOfViewDegrees;
    private int RandomRotate;

    public NavMeshAgent agent;
//    public Animation anim;

    public Transform CoopAI,Enemy,player,FollowPL;

    public bool isFreandly = false;

    private void Awake()
    {
//        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        CorotineAttack = AttackPlayer(timeToShot);
//        StartCoroutine(CorotineAttack);
    }
    private void FixedUpdate()
    {
        EnemyS();
    }

    IEnumerator AttackPlayer(float timeToShot)
    {
        //Make sure enemy doesn't move
//        agent.SetDestination(transform.position);
        transform.LookAt(player);
//        for (int i = 3; i!=0;i--)
//        {
        Ray ray = new Ray(Weapon.transform.position, Weapon.transform.forward);
        RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Distance))
            {
            yield return new WaitForSeconds(timeToShot);
            hit.collider.gameObject.SendMessageUpwards("ChangeHealth", -Damage, SendMessageOptions.DontRequireReceiver);
            Reloadtime = MyTime;
            StopAllCoroutines();
//            StopCoroutine(CorotineAttack);
            }
//        }
    }
    protected void EnemyS()
    {
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - transform.position;
        if ((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfViewDegrees * 0.5f)
        {
            // Detect if player is within the field of view
            if (Physics.Raycast(transform.position, rayDirection, out hit, visibilityDistance))
            {
                if (hit.transform.CompareTag("Player")) 
                {
                    StartCoroutine(AttackPlayer(timeToShot));
                }
//else if (hit.transform.CompareTag(""))
            }
        }
        else
        {
            RandomRotate = Random.Range(1,5);
            transform.Rotate(0f,RandomRotate,0f,Space.Self);
        }
    }
}
