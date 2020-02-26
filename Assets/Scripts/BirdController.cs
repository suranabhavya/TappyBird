using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float upForce = 200f;
    Rigidbody2D rb;
    Animator Anim;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));
                GameManager.instance.playSoundJump();
                Anim.SetTrigger("FlapDown");
                Anim.SetTrigger("FlapUp");
            }
        }
    }
    void OnCollisionEnter2D()
    {
        isDead = true;
        GameManager.instance.BirdDied();
    }
}
