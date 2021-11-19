using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
  public float speed = 5.0f;
  public float obstacleRande = 5f;
  public bool _alive = true;
  public float HP = 3;
    // Start is called before the first frame update
    private void Start()
    {
      _alive = true;
    }

    // Update is called once per frame
    private  void Update()
    {
      if (_alive)
      {
        transform.Translate(0,0, speed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
          GameObject hitObject = hit.transform.gameObject;
          ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
          if (hitObject.GetComponent<CharacterController>())
          {
            HP = HP-1;
            if (HP==0)
            {
                target.ReactToHit();
              }
          }
          else if (hit.distance < obstacleRande)
          {
            float angleRotation = Random.Range(-100, 100);
            transform.Rotate(0, angleRotation,0);
          }
        }
      }
    }
    public void SetAlive(bool alive)
    {
      _alive = alive;
    }


}
