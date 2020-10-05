using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public int currentScene = 0;
    public static void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public static void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextInstance()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void LoadSceneInstance(int i)
    {
        CustomSceneManager.LoadScene(i);
    }

}
