using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private bool _onOff1;
    private bool _onOff2;
    private bool _onOff3;
    public GameObject Hud;
    public GameObject myBag;
    public GameObject synthesis;
    private int count;
    private int temp;
    public GameObject player;
    private PlayerController playerController;
    private RAYCastPickup rAYCastPickup;
    private PlayerStatus playerStatus;
    // Start is called before the first frame update
    void Start()
    {
        _onOff1 = true;
        _onOff2 = true;
        _onOff3 = true;
        count = 0;
        temp= 0;
        playerController = player.GetComponent<PlayerController>();
        rAYCastPickup = player.GetComponent<RAYCastPickup>();
        playerStatus= player.GetComponent<PlayerStatus>();  
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && _onOff1 && _onOff2 && _onOff3)
        {
            Debug.Log(_onOff1);

            Debug.Log("Press ESC!");
            Hud.SetActive(_onOff1);
            if (_onOff1)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            _onOff1 = !_onOff1;
            count++;
            playerController.enabled= false;
            rAYCastPickup.enabled= false;
            playerStatus.enabled= false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !_onOff1)
        {
            if(count == temp)
            {
                Hud.SetActive(_onOff1);
                Cursor.lockState = CursorLockMode.Locked;
                _onOff1 = !_onOff1;
                playerController.enabled = true;
                rAYCastPickup.enabled = true;
                playerStatus.enabled = true;

            }
        }

        if (Input.GetKeyDown(KeyCode.B) && _onOff1 && _onOff2 && _onOff3)
        {
            Debug.Log("Press B");

            myBag.SetActive(_onOff2);
            if (_onOff2)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            _onOff2 = !_onOff2;
            count++;
            playerController.enabled = false;
            playerStatus.enabled= false;
            rAYCastPickup.enabled = false;

        }

        if (Input.GetKeyDown(KeyCode.B) && !_onOff2)
        {
            if(count ==temp) { 
                Cursor.lockState = CursorLockMode.Locked;
                myBag.SetActive(_onOff2);
                _onOff2 = !_onOff2;
                playerController.enabled = true;
                playerStatus.enabled= true;
                rAYCastPickup.enabled = true;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.V) && _onOff1 && _onOff2 && _onOff3)
        {

            synthesis.SetActive(_onOff3);
            if (_onOff3)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            _onOff3 = !_onOff3;
            count++;
            playerController.enabled = false;
            playerStatus.enabled= false;
            rAYCastPickup.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.V) && !_onOff3)
        {
            if (count == temp)
            {
                Cursor.lockState = CursorLockMode.Locked;
                synthesis.SetActive(_onOff3);
                _onOff3 = !_onOff3;
                playerStatus.enabled= true;
                playerController.enabled = true;
                rAYCastPickup.enabled = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && !_onOff1)
        {
            temp += 1;
        }

        if (Input.GetKeyDown(KeyCode.B) && !_onOff2)
        {
            temp += 1;
        }

        if (Input.GetKeyDown(KeyCode.V) && !_onOff3)
        {
            temp += 1;
        }
    }
}
