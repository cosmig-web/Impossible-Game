using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.5f;
    public Vector3 startPos;
    private AudioSource audioSource;
    public bool move = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startPos = transform.position;
         
    }

    void Update()
    {
        if (move)
        {
            var x = Input.GetAxisRaw("Horizontal");
            var z = Input.GetAxisRaw("Vertical");

            transform.position += new Vector3(x, 0, z).normalized * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            audioSource.Play();
            move = false;
            Invoke("ReloadScene", 3);
        }
    }

    void ReloadScene()
    {
        var SceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(SceneName);
        transform.position = startPos;
       
    }
}
