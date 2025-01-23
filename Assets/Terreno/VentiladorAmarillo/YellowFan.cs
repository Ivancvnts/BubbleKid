using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFan : MonoBehaviour
{
    [SerializeField] bool isOn;
    [SerializeField] float force;

    public GameObject windEffects;

    private void Start()
    {
        force *= 100000;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colision");
        if (isOn && collision.CompareTag("Bubble"))
        {
            Debug.Log("Empujar burbuja");
            // Llama al método de la burbuja para establecer la velocidad horizontal
            Bubble bubble = collision.GetComponent<Bubble>();
            if (bubble != null)
            {
                Vector3 direction = transform.right; // Dirección local del ventilador
                bubble.SetHorizontalSpeed(force * direction.x);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bubble"))
        {
            // Llama al método de la burbuja para iniciar la desaceleración
            Bubble bubble = collision.GetComponent<Bubble>();
            if (bubble != null)
            {
                bubble.ReduceHorizontalSpeed();
            }
        }
    }

    

    public void Activate()
    {
        isOn = true;
        windEffects.SetActive(true);
        Debug.Log("FanActivated");
    }
}
