using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    bool dragged = false;

    [Header("General Settings")]
    //Settings
    [SerializeField]
    float speed=1;
    [SerializeField]
    Vector2 direction = -Vector2.right;
    [SerializeField]
    Transform tranLeft, tranRight;


    [Header("Win-Lose Conditions")]
    [SerializeField]
    float holdingTime=5f;
    float holdingCountDown;
    [SerializeField]
    float endTime = 10f;

    [Header("Display msgs")]
    public GameObject winDisplay;
    public GameObject defeatDisplay;

    private void Awake()
    {
        holdingCountDown = holdingTime;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke("EndDefeat", endTime);
    }
    void OnMouseDrag()
    {
        dragged = true;
        rb.bodyType = RigidbodyType2D.Static;
        Vector3 pos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        transform.position = pos;
    }

    public void OnMouseUp()
    {
        //This event triggers when the mouseclick is released **not only after dragging something so we check if we have dragged something before
        if (dragged)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            dragged = false;
            holdingCountDown = holdingTime;
        }
    }
    private void FixedUpdate()
    {
        //Moves the player left
        if (!dragged)
        {   
            rb.velocity = new Vector2(direction.x * Time.deltaTime * speed, rb.velocity.y);
        }

        //Teleports the player to the right side of the scene
        if(tranLeft.position.x > transform.position.x)
        {
            transform.position = new Vector3(tranRight.position.x,transform.position.y, transform.position.z);
        }
    }

    private void Update()
    {
        
        if (dragged)
        {
            holdingTime -= 1 * Time.deltaTime;
            if (holdingTime <= 0)
            {
                CancelInvoke();
                EndVictory();
            }
        }

        
    }

    private void EndDefeat()
    {
        Debug.Log("Defeat");
        defeatDisplay.SetActive(true);
        Invoke("ChangeScene", 2f);
    }
    private void EndVictory()
    {
        winDisplay.SetActive(true);
        Debug.Log("Victory");
        Invoke("ChangeScene", 2f);
    }
    private void ChangeScene()
    {
        CustomSceneManager.LoadNext();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(tranLeft.position,new Vector3(1,1,1));
        Gizmos.DrawCube(tranRight.position, new Vector3(1, 1, 1));
    }

}