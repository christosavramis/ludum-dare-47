using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;



public class CartScript : MonoBehaviour
{

    [Range(0,360)]
    public float stoprad;
    bool dragged = false;
    public float endrad;
    public bool stopped = false;
    public bool stop = false;
    public TMP_Text message;

    void OnMouseDrag()
    {
        dragged = true;
        Debug.Log("Dragging.");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
         if(transform.eulerAngles.z > stoprad && !stopped)
        {
            stopped = true;
            stop = true;
            message.enabled = true;

        }

        if (transform.eulerAngles.z > endrad && stopped && transform.eulerAngles.z < 300)
        {
            stop = true;
            Debug.Log("end scene");
        }
        if (!stop)
        {
            transform.Rotate(new Vector3(0f, 0f, 150f) * Time.deltaTime);
            Debug.Log(transform.eulerAngles.z);
             
        }
        if (dragged)
        {
            stop = false;
            message.text = "Well Done!";
        }

    }

}
