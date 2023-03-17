using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSC : MonoBehaviour
{

    private void OnTriggerEnter(Collider Other) // exit
    {
        SceneManager.LoadScene("RoomB"); // bool
        PlayerPrefs.SetInt("BuyedWeapon", 2);
    }
    // OnTriggerStay/OnColliderStay - беполезные!
    // Они не работю каждый тик.
}
