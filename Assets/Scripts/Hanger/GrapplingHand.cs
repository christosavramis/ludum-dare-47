using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHand : MonoBehaviour
{
    public Camera cam;

    public Transform firepoint;
    public LayerMask grapplingArea;
    public Hanger hanger;
    public LayerMask mask;
    public float ropeDistance=10f;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RotateHand();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firepoint.position, firepoint.right, ropeDistance, mask);
            if (hitInfo.transform != null)
            {
                hanger.Hang(hitInfo.point);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            hanger.Release();
        }
    }

    void RotateHand()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 distanceVector = new Vector3(mousePos.x, mousePos.y, 0) - transform.position;
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
