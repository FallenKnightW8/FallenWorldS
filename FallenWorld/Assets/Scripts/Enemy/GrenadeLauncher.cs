using UnityEngine;
using System.Collections;

public class GrenadeLauncher : EnemyAiTutorial
{
    [SerializeField] private Rigidbody MySnaryad;
    [SerializeField] private float TimeSemi =1.5f;
    private bool semiCanShot = true;
    protected override void EnemyS()
    {
        base.EnemyS();
    }

    protected override void AttacPlayer()
    {
        transform.LookAt(player);
        {
        StartCoroutine(SemiShoot(TimeSemi));
        canShot = false;
        }
    }

    private IEnumerator SemiShoot(float TimeSemi)
    { int i = 0;
        while (i != queue)
        {
            yield return new WaitForSeconds(TimeSemi);
            Rigidbody clone;
            clone = Instantiate(MySnaryad, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * 50);
            i++;
        }
        semiCanShot = true;
        StopAllCoroutines();
    }
}
