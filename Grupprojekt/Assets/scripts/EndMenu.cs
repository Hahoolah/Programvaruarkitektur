using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }
}
