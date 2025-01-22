using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] float speed;
    
    private bool isExploding = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        speed = speed/ 100;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Pop");
        if (isExploding) return;

        if (collision.gameObject.CompareTag("Spike"))
        {
            
            Explode();
        }
    }

    private void Explode()
    {
        isExploding = true;
        animator.SetTrigger("Explode");
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void DestroyBubble()
    {
        Destroy(gameObject);
    }
}
