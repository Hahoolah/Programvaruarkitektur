using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
   
    public static void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }

   public static void TaskOnClick()
    {
        LaunchGame();
    }
}
