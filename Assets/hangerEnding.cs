using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hangerEnding : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CustomSceneManager.LoadNext();
    }
}
