using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagementOfScenes : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayBut()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuBut()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartBut()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
