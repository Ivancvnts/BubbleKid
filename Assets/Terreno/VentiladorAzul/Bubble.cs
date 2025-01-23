using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] float verticalSpeed;
    [SerializeField] float horizontalDeceleration;

    private float horizontalSpeed = 0f;
    private bool isExploding = false;
    private bool isReducingHorizontalSpeed = false;
    private bool isSpawning = true;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        verticalSpeed = verticalSpeed/ 100;
        horizontalDeceleration = horizontalDeceleration / 100;
        animator = GetComponent<Animator>();
        animator.SetTrigger("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSpawning)
        {
            transform.position += new Vector3(horizontalSpeed, verticalSpeed, 0) * Time.deltaTime;
        }
        
        if(isReducingHorizontalSpeed)
        {
            if (horizontalSpeed > 0)
            {
                horizontalSpeed = Mathf.Max(horizontalSpeed - horizontalDeceleration * Time.deltaTime, 0);

            }
            else if (horizontalSpeed < 0)
            {
                horizontalSpeed = Mathf.Min(horizontalSpeed + horizontalDeceleration * Time.deltaTime, 0);
            }
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isExploding) return;

        if (collision.gameObject.CompareTag("Spike"))
        {
            Explode();
        }
    }

    public Vector2 GetMovementDirection()
    {
        return new Vector2(horizontalSpeed, verticalSpeed);
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

    public void SetHorizontalSpeed(float speed)
    {
        horizontalSpeed = speed;
    }

    public void ReduceHorizontalSpeed()
    {
        isReducingHorizontalSpeed = true;
    }

    public void MoveUp()
    {
        isSpawning = false;
        animator.SetTrigger("MoveUp");
    }
}
