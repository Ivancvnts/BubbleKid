using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }*/

        
    }

     

    //Game Over UI
      

    public void Quit()
    {
        Application.Quit();
    }
}