using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportWallObject : InteractableObject
{
    protected override void Interact()
    {
        Jump();
    }

    public void Jump()
    {
        SceneManager.LoadScene(2);
    }
}
