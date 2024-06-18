using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyDown("f5"))
        {
            if (index == 2)
            {
                SceneManager.LoadScene(2);
            }
            if (index == 3)
            {
                SceneManager.LoadScene(3);
            }

        }
        else if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.visible = true;
        }
    }
}
