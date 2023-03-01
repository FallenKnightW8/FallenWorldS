
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAiTutorial : MonoBehaviour
{
//    public GameObject FR;
    public float Distance,visibl;
    public int Damage;
    private float Reloadtime;
    public float MyTime = 3;
    public float timeRound;
    private float timeToShot = 0.1f;

    public GameObject Weapon;

    public float visibilityDistance;
    public float fieldOfViewDegrees;

    public NavMeshAgent agent;
//    public Animation anim;

    public Transform CoopAI,Enemy,player,FollowPL;

    public bool isFreandly = false;

    private void Awake()
    {
//        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
          EnemyS();
    }

    private void AttackPlayer(){
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        Reloadtime -= Time.deltaTime;
        timeRound = Mathf.Round(Reloadtime);
        transform.LookAt(player);
        if (timeRound == 0)
        {
          for (int i = 3; i!=0;i--)
          {
            timeToShot -= Time.deltaTime;
            if (timeToShot <= 0)
              {
              Ray ray = new Ray(Weapon.transform.position, Weapon.transform.forward);
              RaycastHit hit;
              if (Physics.Raycast(ray, out hit, Distance))
              {
                hit.collider.gameObject.SendMessageUpwards("ChangeHealth", -Damage, SendMessageOptions.DontRequireReceiver);
                Reloadtime = MyTime;
                timeToShot = 0.1f;
              }
            }
          }
      }
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
                if (hit.transform.CompareTag("Player"));
                {
                    AttackPlayer();

                }
            }
        }
      }
}
