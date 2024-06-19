using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    private Animator anim;

    public Texture2D point, dialogue, teleport;

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
                switch (hit.collider.gameObject.tag)
                {
                    case "Ground":
                        Cursor.SetCursor(point, new Vector2(16, 16), CursorMode.Auto);
                        break;
                    case "Interactable":
                        Cursor.SetCursor(dialogue, new Vector2(16, 16), CursorMode.Auto);
                        break;
                    case "Teleport":
                        Cursor.SetCursor(teleport, new Vector2(16, 16), CursorMode.Auto);
                        break;
                }
                if (hit.collider.tag == "Ground")
                {
                    playerAgent.stoppingDistance = 0;
                    playerAgent.SetDestination(hit.point);
                }
                else if (hit.collider.tag == "Interactable" || hit.collider.tag == "Teleport")
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
