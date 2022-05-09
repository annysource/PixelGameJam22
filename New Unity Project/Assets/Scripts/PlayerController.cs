using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
  //  public GameObject levelUpOne;
    public Sprite Voa, Lua;
    public RuntimeAnimatorController voando, deriva;
    private float moveX;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

 
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Nivel2"))
        {

            this.gameObject.GetComponent<SpriteRenderer>().sprite = Voa;
            this.GetComponent<Animator>().runtimeAnimatorController = voando as RuntimeAnimatorController;


        }
        if (collider.gameObject.CompareTag("Nivel3"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Lua;
            this.GetComponent<Animator>().runtimeAnimatorController = deriva as RuntimeAnimatorController;
        }
    }



        void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;
    }

    void OnBecameInvisible()
    {
        GameManager.vivo = false;
        Destroy(this.gameObject);
    }
}
