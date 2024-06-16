using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchAnimation();

        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isCollide = Physics.Raycast(ray, out hit);
            if (isCollide)
            {
                if (hit.collider.tag == "Ground")
                {
                    playerAgent.stoppingDistance = 0;
                    playerAgent.SetDestination(hit.point);
                }
                else if (hit.collider.tag == "Interactable")
                {
                    hit.collider.GetComponent<InteractableObject>().OnClick(playerAgent);
                }

            }
        }

    }

    // move animator
    private void SwitchAnimation()
    {
        anim.SetFloat("Speed", playerAgent.velocity.sqrMagnitude);
    }
}
