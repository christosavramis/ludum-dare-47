using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public static void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void LoadSceneInstance(int i)
    {
        CustomSceneManager.LoadScene(i);
    }
}
