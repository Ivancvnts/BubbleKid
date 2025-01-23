using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   public GameObject pausePanel;

    public void PausePanel()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(false);
    }

}
