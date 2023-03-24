using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomsPlacer : MonoBehaviour
{
    private int RangOfMission = 1; //1 to 5
    

    public Room[] RoomPrefabs;
    public Room[] RoomPrGuns;
    public Room[] RoomPrCooc;
    private int TypeRoom;
    private int RandomChoiseRoom;
    private bool spwnedBossRoom = false;
    private bool FirstRoom = false;

    public Room StartingRoom;

    private Room[,] spawnedRooms;

    public int RoomsAera;
    public int CountOfRooms;

    private void Start()
    {
        spawnedRooms = new Room[RoomsAera, RoomsAera];
        spawnedRooms[0, 1] = StartingRoom;

        TypeRoom = Random.Range(0,1);
        switch (TypeRoom)
        {
        case 0:
            for (int i=0;i != RoomPrGuns.Length;i++)
            {
                RoomPrefabs[i] = RoomPrGuns[i];
            }
            break;
        case 1:
        {
            for (int i=0; i!= RoomPrCooc.Length;i++)
            {
                RoomPrefabs[i] = RoomPrGuns[i];
            }
            break;
            }
        default:
        break;
        }

        for (int i = 0; i < CountOfRooms; i++)
        {
            // Это вот просто убрать чтобы подземелье генерировалось мгновенно на старте
//            yield return new WaitForSecondsRealtime(0f);

            PlaceOneRoom();
        }
    }

    private void PlaceOneRoom()
    {
        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if (spawnedRooms[x, y] == null) continue;

                int maxX = spawnedRooms.GetLength(0) - 1;
                int maxY = spawnedRooms.GetLength(1) - 1;

                if (x > 0 && spawnedRooms[x - 1, y] == null) vacantPlaces.Add(new Vector2Int(x - 1, y));
                if (y > 0 && spawnedRooms[x, y - 1] == null) vacantPlaces.Add(new Vector2Int(x, y - 1));
                if (x < maxX && spawnedRooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y < maxY && spawnedRooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }

        // Эту строчку можно заменить на выбор комнаты с учётом её вероятности, вроде как в ChunksPlacer.GetRandomChunk()
        if (!FirstRoom)
        {
            RandomChoiseRoom = 1;
            FirstRoom = true;
        }
        else RandomChoiseRoom = Random.Range(0, RoomPrefabs.Length);
        if (RoomPrefabs[RandomChoiseRoom].CompareTag("BossRoom") && !spwnedBossRoom)
        {
            spwnedBossRoom = true;
            RandomChoiseRoom = 2;
        }
        else
        {
            RandomChoiseRoom = Random.Range(0, RoomPrefabs.Length-1);
        }

        Room newRoom = Instantiate(RoomPrefabs[RandomChoiseRoom]);
        //RandomChoiseRoom = Random.Range(0,100);


        int limit = 500;
        while (limit-- > 0)
        {
            // Эту строчку можно заменить на выбор положения комнаты с учётом того насколько он далеко/близко от центра,
            // или сколько у него соседей, чтобы генерировать более плотные, или наоборот, растянутые данжи
            Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));
            newRoom.RotateRandomly();

            if (ConnectToSomething(newRoom, position))
            {
                newRoom.transform.position = new Vector3(position.x - 5, 0, position.y - 5) * 10;
                spawnedRooms[position.x, position.y] = newRoom;
                return;
            }
        }

        Destroy(newRoom.gameObject);
    }

    private bool ConnectToSomething(Room room, Vector2Int p)
    {
        int maxX = spawnedRooms.GetLength(0) - 1;
        int maxY = spawnedRooms.GetLength(1) - 1;

        List<Vector2Int> neighbours = new List<Vector2Int>();

        if (room.DoorU != null && p.y < maxY && spawnedRooms[p.x, p.y + 1]?.DoorD != null) neighbours.Add(Vector2Int.up);
        if (room.DoorD != null && p.y > 0 && spawnedRooms[p.x, p.y - 1]?.DoorU != null) neighbours.Add(Vector2Int.down);
        if (room.DoorR != null && p.x < maxX && spawnedRooms[p.x + 1, p.y]?.DoorL != null) neighbours.Add(Vector2Int.right);
        if (room.DoorL != null && p.x > 0 && spawnedRooms[p.x - 1, p.y]?.DoorR != null) neighbours.Add(Vector2Int.left);

        if (neighbours.Count == 0) return false;

        Vector2Int selectedDirection = neighbours[Random.Range(0, neighbours.Count)];
        Room selectedRoom = spawnedRooms[p.x + selectedDirection.x, p.y + selectedDirection.y];

        if(selectedDirection == Vector2Int.up)
        {
            room.DoorU.SetActive(false);
            selectedRoom.DoorD.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.down)
        {
            room.DoorD.SetActive(false);
            selectedRoom.DoorU.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.right)
        {
            room.DoorR.SetActive(false);
            selectedRoom.DoorL.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.left)
        {
            room.DoorL.SetActive(false);
            selectedRoom.DoorR.SetActive(false);
        }

        return true;
    }
}
