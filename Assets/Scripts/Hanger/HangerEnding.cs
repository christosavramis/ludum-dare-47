using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HangerEnding : MonoBehaviour
{
    public static HangerEnding instance;
    public GameObject win, defeat;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Win();
    }

    public void Win()
    {

        win.SetActive(true);
        Invoke("changeScene",2f);
    }

    public void Defeat()
    {
        defeat.SetActive(true);
        Invoke("changeScene",2f);
    }

    public void changeScene()
    {
        CustomSceneManager.LoadNext();
    }
}
