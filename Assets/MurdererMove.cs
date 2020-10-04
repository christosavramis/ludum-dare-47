using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurdererMove : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


}
