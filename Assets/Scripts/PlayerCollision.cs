using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 1f;


    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {           
            Invoke("ReloadLevel", levelLoadDelay);
        }

    }

    private void ReloadLevel ()
    {
        SceneManager.LoadScene(0);
    }
    

    
}
