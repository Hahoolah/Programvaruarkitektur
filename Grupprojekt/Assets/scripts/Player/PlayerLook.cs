using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    CameraShake cameraShake; //camera shake object.
    public float mouseSens = 10;
    private float x = 0, y = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraShake = gameObject.GetComponent<CameraShake>(); // getting the camera shake component from the camera.
    }

    // Update is called once per frame
    void Update()
    {
        x += -Input.GetAxis("Mouse Y") * mouseSens;
        y += Input.GetAxis("Mouse X") * mouseSens;

        x = Mathf.Clamp(x, -90, 90);
        transform.localRotation = Quaternion.Euler(x, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, y, 0);

       /* if (Input.GetMouseButtonDown(0)) // if left click, camera shake for 0.15f seconds at magnitude 0.4f.
        {
            StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
        }
       */
    }
}
