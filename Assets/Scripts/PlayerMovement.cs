using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.5f;
    public Vector3 startPos;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startPos = transform.position;
    }

    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");

     transform.position += new Vector3(x, 0, z).normalized * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            audioSource.Play();

            Invoke("ReloadScene", 10);
        }
    }

    void ReloadScene()
    {
        var SceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(SceneName);
    }
}
