using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintUI : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject DialogueUI;
    [SerializeField] private TextMeshProUGUI _promptText;

    public Camera playerCamera;

    private void Start()
    {
        _uiPanel.SetActive(false);
    }

    private void Update()
    {
    }

    public bool IsDisplayed = false;
    public void SetUp(string promptText)
    {

        if (DialogueUI.activeInHierarchy)
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
