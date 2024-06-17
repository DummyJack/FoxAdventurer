using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintUI : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;
    // [SerializeField] private GameObject DialogueUI;
    // [SerializeField] private GameObject GameOverUI;
    [SerializeField] private TextMeshProUGUI _promptText;
    private GameObject DialogueUI;
    private GameObject GameOverUI;

    private void Start()
    {
        _uiPanel.SetActive(false);
        DialogueUI = GameObject.Find("DialogueUI");
        GameOverUI = GameObject.Find("GameOverUI");
    }

    private void Update()
    {
    }

    public bool IsDisplayed = false;
    public void SetUp(string promptText)
    {

        if (DialogueUI.activeInHierarchy | GameOverUI.activeInHierarchy)
        {
            _uiPanel.SetActive(false);
            IsDisplayed = false;
        }
        else
        {
            _promptText.text = promptText;
            _uiPanel.SetActive(true);
            IsDisplayed = true;
        }

    }

    public void Close()
    {
        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }
}
