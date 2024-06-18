using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{

    [SerializeField] private GameObject DialogueUI;
    [SerializeField] private GameObject GameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.activeInHierarchy | GameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }

    }
}
