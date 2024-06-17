using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject turtorialPanel;

    void Start()
    {
        turtorialPanel.SetActive(false);
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("01");
    }

    public void OnEndClick()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }

    public void OnTurtorialClick()
    {
        turtorialPanel.SetActive(true);
    }

    public void CloseTurtorial()
    {
        turtorialPanel.SetActive(false);
    }
}
