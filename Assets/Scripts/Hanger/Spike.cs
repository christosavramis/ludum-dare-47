using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameObject destroyedParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        GameObject go = Instantiate(destroyedParticles, collision.contacts[0].otherCollider.transform.position, collision.contacts[0].otherCollider.transform.rotation);
        AudioManager.instance.PlaySound("brock");
        Destroy(collision.contacts[0].otherCollider.gameObject);
        Destroy(go, 6f);
    }
}
