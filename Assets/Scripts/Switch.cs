using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool _onOff = true;
    public GameObject Hud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)) {
            Debug.Log("Press B!");
            Hud.SetActive(_onOff);
            if (_onOff)
            {
                Cursor.lockState = CursorLockMode.None;
            }else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            _onOff = !_onOff;   
        }
    }
}
