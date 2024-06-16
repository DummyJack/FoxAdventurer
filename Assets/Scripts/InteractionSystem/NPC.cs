using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public string name;
    public string[] contentList;

    public bool Interact(Interactor interactor)
    {
        if (InteractionPrompt == "抓取")
        {
            GameOverUI.Instance.Show();
        }
        DialogueUI.Instance.Show(name, contentList);
        return true;
    }
}
