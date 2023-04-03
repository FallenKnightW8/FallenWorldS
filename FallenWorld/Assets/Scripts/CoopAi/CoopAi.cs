using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class CoopAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject Weapon;
    public float Distance;
    public int Damage = 100;
    [SerializeField]private float TimeReload = 3f;
    private float visibilityDistance = 50;
    private float fieldOfViewDegrees = 180;
    public Transform Enemy;
    private bool canShot = true;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        Enemy = GameObject.FindWithTag("Enemy").transform;
        //        Enemy = GameObject.FindWithTag("Enemy").transform;
        Coop();

    }
    protected virtual void Coop()
    {
        RaycastHit hit;
        Vector3 rayDirection = Enemy.transform.position - transform.position;
        if ((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfViewDegrees * 0.5f)
        {
            // Detect if player is within the field of view
            if (Physics.Raycast(transform.position, rayDirection, out hit, visibilityDistance))
            {
                if (hit.transform.CompareTag("Enemy") && canShot)
                {
                    Enemy = hit.transform;
                    AttacEnemy();
                    transform.LookAt(Enemy);
                }
                else if (!hit.transform.CompareTag("Enemy") && canShot)
                {
                    agent.SetDestination(Enemy.position);
                }
                else if (!canShot)
                {
                    StartCoroutine(Reload(TimeReload));
                }
            }
        }
    }
    protected virtual void AttacEnemy()
    {
        agent.SetDestination(transform.position);
        Ray ray = new Ray(Weapon.transform.position, Weapon.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Distance))
        {
            hit.collider.gameObject.SendMessageUpwards("ChangeHealth", -Damage, SendMessageOptions.DontRequireReceiver);
            canShot = false;
        }
    }
    IEnumerator Reload(float TimeReload)
    {
        yield return new WaitForSeconds(TimeReload);
        canShot = true;
        StopAllCoroutines();
    }
}
