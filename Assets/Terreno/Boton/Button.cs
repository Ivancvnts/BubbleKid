using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject yellowFanToActivate;

    private Animator animator;
    private bool alreadyPressed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !alreadyPressed)
        {
            alreadyPressed = true;
            animator.SetTrigger("Activate");
            yellowFanToActivate.GetComponent<YellowFan>().Activate();
        }
    }
}
