using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looping_guy_GameManager : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10f;    

    public GameObject npc;

    protected string testString;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        //Debug.Log(testString);
    }

    void Timer()
    {
        currentTime -= 1 * Time.deltaTime;
        if (currentTime < 0)
        {
            //Debug.Log("Time up");
            Debug.Log(currentTime);
            GameOver("defeat");            
        }        
    }

    protected void GameOver(string gameOver)
    {
        if (gameOver.Equals("defeat"))
        {
            Debug.Log("Lost mini-game");
        }
        else
        {
            Debug.Log("won mini-game");
        }
        //change scene
    }
}
