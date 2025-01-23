using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrofeoManager : MonoBehaviour
{
    [SerializeField] private string GabyGymNivel2; // Nombre de la siguiente escena

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que toca es el Player
        if (other.CompareTag("Player"))
        {
            Collect(); // Llama a la función para recolectar
        }
    }

    void Collect()
    {
        Debug.Log("Objeto recolectado. Cambiando de escena...");
        // Desactiva o destruye el objeto recolectable
        gameObject.SetActive(false);

        // Cambia a la siguiente escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
