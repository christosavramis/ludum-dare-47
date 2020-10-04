using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCMovement : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;    

    Vector2 direction = -Vector2.right;

   
    
    void Start()
    {
        rb.velocity = direction * moveSpeed;
    }

    void FixedUpdate()
    {
        // Movement
        //rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);

        Vector3 screenTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        if (transform.position.x < screenBottomLeft.x)
        {
            rb.MovePosition(new Vector2(screenTopRight.x, transform.position.y));
            Debug.Log("Start again");
        }
    }

    
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        //rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
    
}
