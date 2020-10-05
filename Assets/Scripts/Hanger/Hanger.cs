using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanger : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;
    public Rigidbody2D rb;
    public float speed = 2f;
    Vector2 pos;
    public Transform firepoint;
    public float minDistance = 4f;
    private bool pull = true;
    public Transform cameraTarget;

    // Start is called before the first frame update
    void Awake()
    {
        _distanceJoint.enabled = false;
        _lineRenderer.enabled = false;
        mainCamera.GetComponent<Camera2DFollow>().target = cameraTarget;
    }

    public void Hang(Vector2 pos)
    {
        this.pos = pos;
        pull = true;
        _lineRenderer.SetPosition(0, pos);
        _lineRenderer.SetPosition(1, firepoint.position);
        _distanceJoint.connectedAnchor = pos;
        _distanceJoint.enabled = true;
        _lineRenderer.enabled = true;
        _distanceJoint.autoConfigureDistance = false;
    }
    public void Release()
    {
        pull = false;
        _distanceJoint.autoConfigureDistance = true;
        _distanceJoint.enabled = false;
        _lineRenderer.enabled = false;
    }

    private void Update()
    {
        if (_lineRenderer.enabled)
        {
            _lineRenderer.SetPosition(0, pos);
            _lineRenderer.SetPosition(1, firepoint.position);
        }
    }
    private void FixedUpdate()
    {
        if (_distanceJoint.enabled)
        {
            if(_distanceJoint.distance > minDistance)
            {
                _distanceJoint.distance -= speed * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            HangerEnding.instance.Defeat();
        }
    }
}


