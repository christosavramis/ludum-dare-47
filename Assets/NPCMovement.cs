using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCMovement : looping_guy_GameManager, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{    
    public float moveSpeed = 5f;

    public Rigidbody2D rb;    

    Vector2 direction = -Vector2.right;

    public int beingGrabbed = 1;

    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;

    
    float startingTimeVictory = 5f;
    float currentTimeVictory = 5f;


    void FixedUpdate()
    {
        // Movement
        //rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        rb.velocity = direction * moveSpeed * beingGrabbed;
        NPCMovesLeft();

        if(beingGrabbed == 0)
        {
            currentTimeVictory -= 1 * Time.deltaTime;
            if (currentTimeVictory < 0)
            {
                GameOver("victory");
            }
        }


    }    

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        //testString = "testString text";
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rb.bodyType = RigidbodyType2D.Static;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; //canvas.scaleFactor
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ContinueMovement();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ContinueMovement();
    }

    private void ContinueMovement()
    {
        beingGrabbed = 1;
        rb.bodyType = RigidbodyType2D.Dynamic;
        currentTimeVictory = startingTimeVictory;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
        beingGrabbed = 0;
        
        //rb.gravity = false;
    }
    
    private void NPCMovesLeft()
    {
        Vector3 screenTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        if (transform.position.x<screenBottomLeft.x)
        {
            rb.MovePosition(new Vector2(screenTopRight.x, transform.position.y));
            //Debug.Log("Start again");
        }
    }



}
