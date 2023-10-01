using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string mapScene;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(mapScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
