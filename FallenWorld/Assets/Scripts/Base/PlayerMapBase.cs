using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapBase : MonoBehaviour
{
    public KeyCode JobButton;
    public KeyCode CloseButon;

    public int isTRue = 0;

    public GameObject TXT;

    public GameObject MapB;
    public GameObject Table;

    public ChangeWeaponOnBase job;

    public GameObject player;
    public GameObject playerC;

    void Update()
    {
        StartCoroutine(Check());
    }
    public IEnumerator Check()
    {
        if (isTRue == 0) ray();
        else if (Input.GetKeyDown(CloseButon) && isTRue == 1)
        { 
            Close();
            yield return new WaitForSeconds(0.1f);
        }

    }
    public void ray()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider.GetComponent<Map>())
            {
                Map();
            }
            else if (hit.collider.GetComponent<PCSHOP>())
            {
                pc();
            }
        }
        else
        {
            TXT.SetActive(false);
        }

    }

    public void pc()
    {
        TXT.SetActive(true);
        if (Input.GetKeyDown(JobButton))
        {

            isTRue = 1;
            Table.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            player.GetComponent<FirstPersonCharacter>().lockCursor = false;
            player.GetComponent<FirstPersonCharacter>().lockMove = true;
        }
    }
        public void Map()
        {
        TXT.SetActive(true);
        if (Input.GetKeyDown(JobButton))
        {
            isTRue = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            MapB.SetActive(true);
            TXT.SetActive(false);
            player.GetComponent<FirstPersonCharacter>().lockCursor = true;
//            player.GetComponent<FirstPersonMovement>().CanMove = false;
//            player.GetComponent<FirstPersonLook>().canM = false;
        }
    }

    public void Close()
    {
        isTRue = 0;
        MapB.SetActive(false);
        Table.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<FirstPersonCharacter>().lockCursor = true;
        player.GetComponent<FirstPersonCharacter>().lockMove = false;
    }
}
