using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenStartDoor : MonoBehaviour
{
    public Text text;
    public string levelName;
    private bool inDoor = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(false);
            inDoor = false;
        }
    }

    private void Update()
    {
        if (inDoor && Input.GetKey("e"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
            
        
    }

}
