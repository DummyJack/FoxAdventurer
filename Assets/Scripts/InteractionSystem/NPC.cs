using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public string name;
    public string[] contentList;

    public bool Interact(Interactor interactor)
    {
        DialogueUI.Instance.Show(name, contentList);
        return true;
    }
}
