using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float mouseSens = 10;
    private float x = 0, y = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        x += -Input.GetAxis("Mouse Y") * mouseSens;
        y += Input.GetAxis("Mouse X") * mouseSens;

        x = Mathf.Clamp(x, -90, 90);
        transform.localRotation = Quaternion.Euler(x, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, y, 0);

    }
}
