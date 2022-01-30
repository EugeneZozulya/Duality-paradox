using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject HellGameOverPanel;
    public Image image;
    public void Restart()
    {
        //HellGameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Play()
    {
        HellGameOverPanel.SetActive(false);

        SceneManager.LoadScene(1);

    }
}
