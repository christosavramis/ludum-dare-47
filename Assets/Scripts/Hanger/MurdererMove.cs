using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MurdererMove : MonoBehaviour
{
    public float speed = 1f;
    public Animator flameAnimator;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enraged");
        GetComponent<Animator>().SetBool("Enraged", true);
        if (collision.transform.tag == "Enraged")
        {
            GetComponent<Animator>().SetBool("Enraged", true);
        }

    }
    public void Enrage()
    {
        GetComponent<Animator>().SetBool("Enraged", false);
        AudioManager.instance.PlaySound("yell");
        Invoke("lateEnrage",2.5f);
        flameAnimator.SetFloat("Test", 1);
    }
    
    void lateEnrage()
    {
        AudioManager.instance.PlaySound("mainthemeEnraged");
    }

}
