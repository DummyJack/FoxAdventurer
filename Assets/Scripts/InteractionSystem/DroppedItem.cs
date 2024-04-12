using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroppedItem : MonoBehaviour, IInteractable
{
    Vector3 vector = new Vector3(1, 0, 1);

    [SerializeField] private string _prompt;
    [SerializeField] private GameObject _gameObject;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        
        if (!interactor.TryGetComponent<Inventory>(out var inventory)) return false;

        if (inventory.isFull) {
            Debug.Log("Inventory is full, can't interact with Dropped Item");
            return false;
        }
        // Instantiate(_gameObject, position: _gameObject.transform.position + vector, rotation: Quaternion.identity);
        // Destroy(_gameObject);
        
        _gameObject.transform.position += vector;
        Debug.Log("Interact with Dropped Item");
        return true;
    }
    
}
