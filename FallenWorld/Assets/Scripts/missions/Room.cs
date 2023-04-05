using UnityEngine;
//using UnityEditor.AI;

public class Room : MonoBehaviour
{
    public GameObject DoorU;
    public GameObject DoorR;
    public GameObject DoorD;
    public GameObject DoorL;

    public GameObject[] spawns;
    private GameObject ActiveSpawn;
    public GameObject prefabToSpawn;
    private int RandomSp;

//    public NavMeshBuilder NavMeshBuilder;

    public Mesh[] BlockMeshes;


    private void Start()
    {
        //        NavMeshBuilder.BuildNavMesh();
        RandomSp = Random.Range(0,spawns.Length);
        SetSpawn(RandomSp);

        foreach (var  filter in GetComponentsInChildren<MeshFilter>())
        {
            if (filter.sharedMesh == BlockMeshes[0])
            {
                filter.sharedMesh = BlockMeshes[Random.Range (0, BlockMeshes.Length)];
                filter.transform.rotation = Quaternion.Euler(-90, 0, 90  * Random.Range (0, 4));
            }
        }
    }

    public void SetSpawn(int RandomSp)
    {
        if (spawns[0] != null)
        {
            spawns[RandomSp].SetActive(true);
            ActiveSpawn = spawns[RandomSp];
            Spawn();
        }
    }

    public void RotateRandomly()
    {
        int count = Random.Range(0, 4);

        for (int i = 0; i < count; i++)
        {
            transform.Rotate(0, 90, 0);

            GameObject tmp = DoorL;
            DoorL = DoorD;
            DoorD = DoorR;
            DoorR = DoorU;
            DoorU = tmp;
        }
    }
    void Spawn()
    {
        if (prefabToSpawn != null && spawns[0] != null)
        {
            Instantiate(prefabToSpawn, ActiveSpawn.transform.position, Quaternion.identity);
        }
    }
}
