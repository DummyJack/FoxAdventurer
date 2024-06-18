using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance { get; private set; }
    private Button Restart;
    private Button BackToMenu;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject); return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    public void Show()
    {
        Cursor.visible = true;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


    public void OnRestartClick()
    {
        SceneManager.LoadScene(3);
    }

    public void OnBackToMenuClick()
    {
        SceneManager.LoadScene(0);
    }
}
