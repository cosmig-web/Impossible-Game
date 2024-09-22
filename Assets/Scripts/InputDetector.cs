using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputDetector : MonoBehaviour
{
    public string sceneName = "Level 2";
    
    void Update()
    {
       if(Input.anyKey)
        {
            SceneManager.LoadScene(sceneName);

        }
    }
}
