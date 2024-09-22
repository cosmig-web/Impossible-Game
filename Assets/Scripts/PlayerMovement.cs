using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    public Vector3 startPos;

    void Start()
    {
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
            transform.position = startPos;
        }
    }
}
