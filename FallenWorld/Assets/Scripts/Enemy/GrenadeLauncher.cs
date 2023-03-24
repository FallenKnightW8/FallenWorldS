using UnityEngine;

public class GrenadeLauncher : EnemyAiTutorial
{
    [SerializeField] private Rigidbody MySnaryad;
    protected override void EnemyS()
    {
        base.EnemyS();
    }

    protected override void AttacPlayer()
    {
        transform.LookAt(player);
        {
            for (int i = 0; i < queue; i++)
            {
                Rigidbody clone;
                clone = Instantiate(MySnaryad, transform.position, transform.rotation) as Rigidbody;
                clone.velocity = transform.TransformDirection(Vector3.forward * 50);
            }
            canShot = false;
        }
    }


}
