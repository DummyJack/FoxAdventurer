using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private HintUI _hintUI;

    private readonly Collider[] _colliders = new Collider[3];

    // [SerializeField] private int _numFound;
    private int _numFound;

    private IInteractable _interactable;

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        if (_numFound > 0)
        {
            _interactable = GetClosestCollider().GetComponent<IInteractable>();
            // _interactable = _colliders[0].GetComponent<IInteractable>();

            if (_interactable != null)
            {
                // if (!_hintUI.IsDisplayed) 
                _hintUI.SetUp(_interactable.InteractionPrompt);

                if (Keyboard.current.eKey.wasPressedThisFrame) _interactable.Interact(this);
            }

        }
        else
        {
            if (_interactable != null) _interactable = null;
            if (_hintUI.IsDisplayed) _hintUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }

    private Collider GetClosestCollider()
    {
        Collider closestCollider = _colliders[0];
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = _interactionPoint.position;

        for (int i = 0; i < _colliders.Length; i++)
        {
            if (_colliders[i] != null)
            {
                Vector3 directionToTarget = _colliders[i].transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    closestCollider = _colliders[i];
                }
            }
        }

        return closestCollider;
    }
}
