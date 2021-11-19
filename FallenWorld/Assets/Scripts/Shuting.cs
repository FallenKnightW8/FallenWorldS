using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuting : MonoBehaviour
{
  public float damage = 21;
  public float fireRate = 1;
  public float range = 15;
  public float force = 155;
  public Transform bulletSpawn;
  public ParticleSystem muzzleFlash;
  public AudioClip shotSFX;
  public AudioSource _audioSource;
  public Camera _cam;
  public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
      if  (Input.GetButtonDown("Fire1"))
      {
        Shoot();
      }
    }
    void Shoot()
    {
      _audioSource.PlayOneShot(shotSFX);
      muzzleFlash.Play();
      RaycastHit hit;
      if (Physics.Raycast(_cam.transform.position,_cam.transform.forward,out hit,range))
      {
        GameObject impact = Instantiate(hitEffect,hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact,2f);
        GameObject hitObject = hit.transform.gameObject;
        ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

        if(hit.rigidbody !=null)
        {
          hit.rigidbody.AddForce(-hit.normal*force);
          target.ReactToHit();
        }
      }

    }


}
