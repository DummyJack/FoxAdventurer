using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportWall01Object : InteractableObject
{
    protected override void Interact()
    {
        print("Interact");
    }

    // public void Jump()
    // {
    //     SceneManager.LoadScene(2);
    // }
}
