using UnityEngine;

public class SpawnRandomWeapon : MonoBehaviour
{
    public int IdOfWeapon;
    [SerializeField] private GameObject[] ModelsWeapons;
    void Start()
    {
        IdOfWeapon = Random.Range(0, 4);
        Instantiate(ModelsWeapons[IdOfWeapon], transform.position, transform.rotation);
    }
    public void destroy()
    {
        Destroy(gameObject);
    }

}
